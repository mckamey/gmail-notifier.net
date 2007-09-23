using System;
using System.Collections.Generic;

using MediaLib.Web.Feeds.Atom;

namespace Notifier.Providers
{
	public class GmailProvider : XmlNotifierProvider<AtomFeed03>
	{
		#region Constants

		private const string FeedUrlFormat = "https://mail.google.com/{0}/feed/atom/{1}";
		private const string IsGmail = "mail";
		private const string IsGoogleApps = "a/{0}";

		#endregion Constants

		#region Fields

		private string username = null;
		private string password = null;
		private string feedUrl = null;

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor.
		/// </summary>
		public GmailProvider(string username, string password) : this(username, password, "unread")
		{
		}

		/// <summary>
		/// Ctor.
		/// </summary>
		public GmailProvider(string username, string password, string label)
		{
			if (String.IsNullOrEmpty(username))
			{
				throw new ArgumentNullException("username");
			}
			if (String.IsNullOrEmpty(password))
			{
				throw new ArgumentNullException("password");
			}

			this.username = username;
			this.password = password;

			string domain = username.Substring(username.IndexOf('@')+1);
			if (String.IsNullOrEmpty(domain))
			{
				this.feedUrl = String.Format(
					GmailProvider.FeedUrlFormat,
					GmailProvider.IsGmail,
					label);
			}
			else
			{
				this.feedUrl = String.Format(
					GmailProvider.FeedUrlFormat,
					String.Format(GmailProvider.IsGoogleApps, domain),
					label);
			}
		}

		#endregion Init

		#region Properties

		protected override string FeedUrl
		{
			get { return this.feedUrl; }
		}

		protected override string Username
		{
			get { return this.username; }
		}

		protected override string Password
		{
			get { return this.password; }
		}

		protected override string Domain
		{
			get { return String.Empty; }
		}

		#endregion Properties

		#region SerializedFeed Method

		protected override List<Notification> ParseFeed(AtomFeed03 feed)
		{
			List<Notification> msgs = new List<Notification>(feed.Entries.Count);
			foreach (AtomEntry03 entry in feed.Entries)
			{
				Notification msg = new Notification(entry.ID);
				msg.Title = entry.Title.Value;
				if (entry.Authors.Count > 0)
				{
					msg.Author =
					String.IsNullOrEmpty(entry.Authors[0].Name) ?
					entry.Authors[0].Email :
					entry.Authors[0].Name;
				}
				msg.Body = entry.Summary.Value;
				msg.Date = entry.Modified.Value;
				msg.Index = msgs.Count+1;
				msg.Count = feed.Entries.Count;
				msgs.Add(msg);
			}
			return msgs;
		}

		#endregion SerializedFeed Method
	}
}
