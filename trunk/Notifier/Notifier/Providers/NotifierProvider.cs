using System;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System.Net;

namespace Notifier.Providers
{
	public abstract class NotifierProvider
	{
		#region Constants

		private const string AuthType = "Basic";

		#endregion Constants

		#region Fields

		private Uri serviceUri = null;
		private NetworkCredential credentials = null;

		#endregion Fields

		#region Properties

		protected Uri ServiceUri
		{
			get
			{
				if (this.serviceUri == null)
				{
					this.serviceUri = new Uri(this.ServiceUrl);
				}
				return this.serviceUri;
			}
		}

		protected ICredentials Credientials
		{
			get
			{
				if (this.credentials == null)
				{
					if (String.IsNullOrEmpty(this.Username) || String.IsNullOrEmpty(this.Password))
					{
						return CredentialCache.DefaultCredentials;
					}

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

		/// <summary>
		/// Gets the display name of this provider.
		/// </summary>
		public abstract string ProviderName
		{
			get;
		}

		/// <summary>
		/// Gets the URL to take the user to for further interaction.
		/// </summary>
		public abstract string ProviderUrl
		{
			get;
		}

		/// <summary>
		/// Gets the URL from where the data is retrieved.
		/// </summary>
		protected abstract string ServiceUrl
		{
			get;
		}

		/// <summary>
		/// Gets the username if service is authenticated.
		/// </summary>
		protected abstract string Username
		{
			get;
		}

		/// <summary>
		/// Gets the password if service is authenticated.
		/// </summary>
		protected abstract string Password
		{
			get;
		}

		/// <summary>
		/// Gets the domain if service is authenticated.
		/// </summary>
		protected abstract string Domain
		{
			get;
		}

		#endregion Abstract Properties

		#region Methods

		public List<Notification> GetNotifications()
		{
			Stream stream = null;
			using (WebClient client = new WebClient())
			{
				client.Credentials = this.Credientials.GetCredential(this.ServiceUri, AuthType);
#if DEBUG
				//string debug = client.DownloadString(this.FeedUri);
#endif
				stream = client.OpenRead(this.ServiceUrl);
				return this.ParseFeed(stream);
			}
		}

		#endregion Methods

		#region Abstract Methods

		protected abstract List<Notification> ParseFeed(Stream stream);

		#endregion Abstract Methods
	}
}
