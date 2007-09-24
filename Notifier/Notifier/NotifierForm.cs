using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Notifier.Providers;
using Notifier.Utils;

namespace Notifier
{
	/// <summary>
	/// http://www.developer.com/net/csharp/article.php/3336751
	/// </summary>
	public partial class NotifierForm : Form
	{
		#region Constants

		private const int MSPerSec = 1000;
		private const int MSPerMin = 60*MSPerSec;

		private const int DefaultRefreshRate = 300000;
		private const int MinRefreshRate = 30000;
		private const int DefaultPreviewDelay = 3;
		private const int MinPreviewDelay = 1;

		private const string Config_RefreshRate = "RefreshRateMin";
		private const string Config_PreviewDelay = "PreviewDelaySec";

		private const string Icon_NewMail = "Icons.NewMail.ico";
		private const string Icon_NoMail = "Icons.NoMail.ico";
		private const string Icon_Error = "Icons.Error.ico";
		private const string Icon_App = "App.ico";

		private const string Text_NoMessages = "No unread messages";
		private const string Text_NewMessages = "{0} unread messages";

		#endregion Constants

		#region Fields

		private NotifierProvider provider;
		private int refreshRate = -1;
		private int previewDelay = -1;
		private List<Notification> msgs = new List<Notification>();
		private NotifyMessage notify = null;
		private readonly Dictionary<string, bool> ReadCache = new Dictionary<string, bool>();

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor.
		/// </summary>
		public NotifierForm()
		{
			this.notify = new NotifyMessage(this);

			InitializeComponent();
		}

		#endregion Init

		#region Properties

		protected int RefreshRate
		{
			get
			{
				if (this.refreshRate < MinRefreshRate)
				{
					string rateStr = ConfigurationManager.AppSettings[Config_RefreshRate];
					int rateMin;
					if (Int32.TryParse(rateStr, out rateMin) && rateMin > 0)
					{
						this.refreshRate = MSPerMin * rateMin;
					}
					else
					{
						this.refreshRate = DefaultRefreshRate;
					}
				}
				return this.refreshRate;
			}
		}

		protected int PreviewDelay
		{
			get
			{
				if (this.previewDelay < MinPreviewDelay)
				{
					string rateStr = ConfigurationManager.AppSettings[Config_PreviewDelay];
					int rateSec;
					if (Int32.TryParse(rateStr, out rateSec) && rateSec > 0)
					{
						this.previewDelay = MSPerSec * rateSec;
					}
					else
					{
						this.previewDelay = DefaultPreviewDelay;
					}
				}
				return this.previewDelay;
			}
		}

		#endregion Properties

		#region Methods

		protected void UpdateNotifier(bool showPreviews)
		{
			if (this.provider == null)
			{
				this.Show();
				return;
			}

			List<Notification> msgs = null;
			try
			{
				msgs = this.provider.GetNotifications();
				this.theNotifyIcon.BalloonTipTitle = this.provider.ProviderName;

				if (msgs.Count < 1)
				{
					this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_NoMail);
					this.theNotifyIcon.BalloonTipText = Text_NoMessages;

					if (showPreviews)
					{
						this.theNotifyIcon.ShowBalloonTip(this.PreviewDelay);
					}
					return;
				}

				this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_NewMail);
				this.theNotifyIcon.BalloonTipText = String.Format(Text_NewMessages, msgs.Count);

				if (showPreviews)
				{
					this.theNotifyIcon.ShowBalloonTip(this.PreviewDelay);
				}
			}
			catch (System.Net.WebException ex)
			{
				this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_Error);

				Notification msg = new Notification(ex.Message);
				msg.Title = ex.Status.ToString();
				msg.Body = ex.Message;
				msg.Link = ex.Response.ResponseUri;

				msgs = new List<Notification>();
				msgs.Add(msg);
			}

			if (!showPreviews)
			{
				foreach (Notification msg in msgs)
				{
					if (!this.ReadCache.ContainsKey(msg.ID))
					{
						showPreviews = true;
						break;
					}
				}
			}

			if (showPreviews)
			{
				this.msgs.AddRange(msgs);
				this.DisplayNotifications();
			}
		}

		protected void SignIn(string username, string password)
		{
			this.provider = new GmailProvider(username, password);
			this.Hide();
			this.UpdateNotifier(true);
			this.timerPolling.Interval = this.RefreshRate;
			this.timerPolling.Start();
		}

		protected internal void DisplayNotifications()
		{
			if (this.msgs.Count <= 0)
			{
				this.notify.TimerStop();
				return;
			}

			Notification msg = this.msgs[0];
			this.msgs.RemoveAt(0);
			this.ReadCache[msg.ID] = true;
			this.notify.SetMessage(msg);
			this.notify.TimerStart();
		}

		#endregion Methods

		#region Context Menu Handlers

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.provider == null)
			{
				this.Show();
			}
			else
			{
				this.UpdateNotifier(true);
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion Context Menu Handlers

		#region Timer Handlers

		private void timerPolling_Tick(object sender, EventArgs e)
		{
			this.UpdateNotifier(false);
		}

		#endregion Timer Handlers

		#region NotifyIcon Handlers

		private void theNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.provider != null)
			{
				BrowserUtility.LaunchBrowser(this.provider.ProviderUrl);
			}
			else
			{
				this.UpdateNotifier(true);
			}
		}

		#endregion NotifyIcon Handlers

		#region NotifierForm Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(this.textUsername.Text) && !String.IsNullOrEmpty(this.textPassword.Text))
			{
				this.SignIn(this.textUsername.Text, this.textPassword.Text);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.timerPolling.Stop();
			this.Hide();
		}

		private void NotifierForm_VisibleChanged(object sender, EventArgs e)
		{
			this.textUsername.Text = this.textPassword.Text = null;
			this.textUsername.Focus();
		}

		private void NotifierForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.theNotifyIcon.Visible = false;
		}

		#endregion NotifierForm Handlers
	}
}