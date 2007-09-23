using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Notifier.Providers;

namespace Notifier
{
	/// <summary>
	/// http://www.developer.com/net/csharp/article.php/3336751
	/// </summary>
	public partial class NotifierForm : Form
	{
		#region Constants

		private const int MSPerMin = 60000;
		private const int DefaultRefreshRate = 300000;
		private const int MinRefreshRate = 30000;
		private const string Config_RefreshRate = "RefreshRate";

		private const string Icon_NewMail = "Icons.NewMail.ico";
		private const string Icon_NoMail = "Icons.NoMail.ico";
		private const string Icon_Error = "Icons.Error.ico";

		#endregion Constants

		#region Fields

		private GmailProvider gmail;
		private int refreshRate = -1;

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor.
		/// </summary>
		public NotifierForm()
		{
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

		#endregion Properties

		#region Methods

		protected void UpdateNotifier()
		{
			try
			{
				List<Notification> msgs = this.gmail.GetNotifications();
				if (msgs.Count < 1)
				{
					this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_NoMail);
					this.theNotifyIcon.BalloonTipText = "No new messages.";
					return;
				}

				this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_NewMail);
				this.theNotifyIcon.BalloonTipText = msgs.Count+" new messages.";
				foreach (Notification msg in msgs)
				{
					NotifyMessage notify = new NotifyMessage();
					notify.SetMessage(msg);
					notify.Show();
					//System.Threading.Thread.Sleep(3000);
					//notify.Close();
				}
			}
			catch
			{
				this.theNotifyIcon.Icon = new Icon(typeof(NotifierForm), NotifierForm.Icon_Error);
			}
		}

		protected void SignIn()
		{
			this.gmail = new Notifier.Providers.GmailProvider(this.textUsername.Text, this.textPassword.Text);
			this.Hide();
			this.UpdateNotifier();
			this.theTimer.Interval = this.RefreshRate;
			this.theTimer.Start();
		}

		#endregion Methods

		#region Child Control Events

		private void theTimer_Tick(object sender, EventArgs e)
		{
			this.UpdateNotifier();
		}

		private void theNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.gmail == null)
			{
				this.Show();
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.UpdateNotifier();
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.SignIn();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.theTimer.Stop();
			this.Hide();
		}

		private void NotifierForm_VisibleChanged(object sender, EventArgs e)
		{
			this.textUsername.Text = this.textPassword.Text = null;
		}

		private void NotifierForm_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				this.Hide();
			}
		}

		private void NotifierForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\n' && e.KeyChar != '\r')
			{
				return;
			}

			if (!String.IsNullOrEmpty(this.textUsername.Text) && !String.IsNullOrEmpty(this.textPassword.Text))
			{
				this.SignIn();
			}
		}

		private void NotifierForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.theNotifyIcon.Visible = false;
		}

		#endregion Child Control Events
	}
}