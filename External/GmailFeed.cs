using System;
using System.Collections.Generic;

using Notifier.Atom;

namespace Notifier.Feeds
{
	public class GmailFeed : SerializedFeed<AtomFeed03>
	{
		#region Constants

		private const string FeedUrlFormat = "https://mail.google.com/{0}/feed/atom";
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
		public GmailFeed(string username, string password)
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
					GmailFeed.FeedUrlFormat,
					GmailFeed.IsGmail);
			}
			else
			{
				this.feedUrl = String.Format(
					GmailFeed.FeedUrlFormat,
					String.Format(GmailFeed.IsGoogleApps, domain));
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
			foreach (AtomEntry entry in feed.Entries)
			{
				Notification msg = new Notification();
				msg.Title = entry.Title.Value;
				msg.Author = entry.Author.ToString();
				msg.Body = entry.Summary.Value;
				msg.TimeStamp = entry.Modified.Value;
				msg.Index = msgs.Count+1;
				msg.Count = feed.Entries.Count;
				msgs.Add(msg);
			}
			return msgs;
		}

		#endregion SerializedFeed Method
	}
}