using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Web;

using MediaLib.Web;
using MediaLib.Web.Feeds.Rss;
using MediaLib.Web.Hosting;

namespace MediaLib.Web.Handlers
{
	public class FileBrowserRssHandler : MediaLib.Web.Feeds.Rss.RssHandler
	{
		#region Init

		public FileBrowserRssHandler()
		{
		}

		#endregion Init

		#region RssHandler Members

		protected override RssFeed GenerateRssFeed(System.Web.HttpContext context)
		{
#if DEBUG
			if (!String.IsNullOrEmpty(context.Request.QueryString["url"]))
				return base.GenerateRssFeed(context);
#endif
			if (!FilePathMapper.IsPathVirtual(context.Request.CurrentExecutionFilePath))
				context.Response.Redirect(FilePathMapper.MediaVirtualRoot, true);

			string folderPath = FilePathMapper.GetDirectory(FilePathMapper.GetPhysicalPath(context.Request.CurrentExecutionFilePath));
			return this.GenerateDirectoryListFeed(context, folderPath);
		}

		#endregion RssHandler Members

		#region FileBrowser Methods

		protected RssFeed GenerateDirectoryListFeed(System.Web.HttpContext context, string folderPath)
		{
			string requestUrl = FilePathMapper.GetDirectory(context.Request.Url.AbsoluteUri);
			DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

			RssFeed rssDoc = new RssFeed();
			rssDoc.Channel.Title = ConfigurationManager.AppSettings["SiteName"];
			rssDoc.Channel.Description = HttpUtility.UrlDecode(requestUrl);
			rssDoc.Channel.Copyright = ConfigurationManager.AppSettings["Copyright"];
			rssDoc.Channel.LastBuildDate = DateTime.UtcNow;
			rssDoc.Channel.Generator = rssDoc.Channel.Title+" RSS Generator";
			rssDoc.Channel.Ttl = 86400;
			rssDoc.Channel.Link = requestUrl;
			rssDoc.Channel.Language = System.Globalization.CultureInfo.CurrentCulture.Name;

			if (!folderPath.Equals(FilePathMapper.MediaPhysicalRoot, StringComparison.InvariantCultureIgnoreCase))
			{
				RssItem item = new RssItem();
				item.Title = "Parent Directory";
				item.Link = FilePathMapper.Combine(context.Request.Url.AbsoluteUri, "../");
				item.Guid.Value = HttpUtility.UrlDecode(item.Link);
				item.Guid.IsPermaLink = false;

				rssDoc.Channel.Items.Add(item);
			}

			foreach (FileSystemInfo info in directoryInfo.GetFileSystemInfos())
			{
				RssItem item = new RssItem();
				item.Title = info.Name;
				item.PubDate = info.LastWriteTimeUtc;
				item.Guid.Value = FilePathMapper.Combine(context.Request.Url.AbsoluteUri, FilePathMapper.UrlEncode(info.Name));
				item.Guid.IsPermaLink = false;

				if ((info.Attributes&FileAttributes.Directory) != 0)
				{
					item.Link = item.Guid.Value;

					DirectoryInfo dirInfo = new DirectoryInfo(info.FullName);
					if (dirInfo != null)
					{
						int dirCount = dirInfo.GetDirectories("*", SearchOption.TopDirectoryOnly).Length;
						FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
						item.Description = "Directory ("+dirCount+" directories, "+files.Length+" files)";

						foreach (FileInfo file in files)
						{
							MimeType mime = MimeTypes.GetByExtension(file.Extension);
							if (mime != null)
							{
								if (mime.Category == MimeCategory.Audio)
								{
									// use the M3U link here
									item.Enclosure.Url = item.Guid.Value+"/PlayList.m3u";
									item.Enclosure.Type = MimeTypes.GetContentType(".m3u");
									item.Enclosure.Length = 1L;
									break;
								}
								else if (mime.Category == MimeCategory.Video)
								{
									// use the WPL link here
									item.Enclosure.Url = item.Guid.Value+"/PlayList.wpl";
									item.Enclosure.Type = MimeTypes.GetContentType(".wpl");
									item.Enclosure.Length = 1L;
									break;
								}
							}
						}
					}
				}
				else
				{
					FileInfo fileInfo = new FileInfo(info.FullName);
					if (fileInfo != null)
					{
						MimeType mime = MimeTypes.GetByExtension(info.Extension);
						if (mime != null)
						{
							if (mime.ContentTypes != null && mime.ContentTypes.Length > 0)
								item.Enclosure.Type = mime.ContentTypes[0];
							item.Description = mime.Name+" "+mime.Category+" ";
						}
						item.Description += "File ("+fileInfo.Length+" bytes)";

						item.Enclosure.Url = item.Guid.Value;
						string enclosurePath = item.Link;
						item.Enclosure.Length = fileInfo.Length;
					}
				}
				item.Guid.Value = HttpUtility.UrlDecode(item.Guid.Value);

				rssDoc.Channel.Items.Add(item);
			}

			return rssDoc;
		}

		#endregion FileBrowser Methods
	}
}