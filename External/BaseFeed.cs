using System;
using System.IO;
using System.Security;
using System.Net;

using Notifier.Atom;

namespace Notifier.Feeds
{
	public abstract class BaseFeed
	{
		#region Fields

		private Uri feedUri = null;
		private NetworkCredential credentials = null;

		#endregion Fields

		#region Properties

		protected Uri FeedUri
		{
			get
			{
				if (this.feedUri == null)
				{
					this.feedUri = new Uri(this.FeedUrl);
				}
				return this.feedUri;
			}
		}

		protected NetworkCredential Credientials
		{
			get
			{
				if (this.credentials == null)
				{
					this.credentials = new NetworkCredential();
					this.credentials.UserName = this.Username;
					this.credentials.Password = this.Password;
					this.credentials.Domain = this.Domain;
				}
				return this.credentials;
			}
		}

		#endregion Properties

		#region Abstract Properties

		protected abstract string FeedUrl
		{
			get;
		}

		protected abstract string Username
		{
			get;
		}

		protected abstract string Password
		{
			get;
		}

		protected abstract string Domain
		{
			get;
		}

		#endregion Abstract Properties

		#region Methods

		public int Synchronize()
		{
			try
			{
				Stream stream = null;
				using (WebClient client = new WebClient())
				{
					client.Credentials = this.Credientials.GetCredential(this.FeedUri, "Basic");

#if DEBUG
					//string data = client.DownloadString(this.FeedUri);
#endif

					stream = client.OpenRead(this.FeedUrl);
					AtomFeed03 feed = this.ParseFeed(stream) as AtomFeed03;
					return feed.Entries.Count;
				}
			}
			catch
			{
				return -1;
			}
		}

		#endregion Methods

		#region Abstract Methods

		protected abstract object ParseFeed(Stream stream);

		#endregion Abstract Methods
	}
}
