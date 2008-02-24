using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Notifier.Providers;
using Notifier.Utils;

namespace Notifier
{
	public partial class NotifyMessage : Form
	{
		#region Fields

		private NotifierForm notifierOwner = null;
		private Uri link = null;
		private bool isHovering = false;

		#endregion Fields

		#region Init

		public NotifyMessage(NotifierForm owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}

			this.notifierOwner = owner;

			InitializeComponent();
		}

		#endregion Init

		#region Methods

		public void SetMessage(Notification msg)
		{
			this.lblCount.Visible = msg.Count > 0;
			this.lblDate.Visible = msg.Date.HasValue;

			this.lblAuthor.Text = msg.Author;
			this.lblCount.Text = String.Format("{0}/{1}", msg.Index, msg.Count);
			this.lblTitle.Text = msg.Title;
			this.lblDate.Text = msg.Date.HasValue ?
				msg.Date.Value.ToLocalTime().ToString("MMM dd, yyyy @ HH:mm") :
				String.Empty;
			this.lblBody.Text = msg.Body;
			this.link = msg.Link;
		}

		public void TimerStart()
		{
			this.isHovering = false;
			this.Opacity = 0.80;
			this.BackColor = SystemColors.Control;
			this.Show();
			this.timerPreview.Start();
		}

		public void TimerStop()
		{
			this.isHovering = false;
			this.Hide();
			this.Opacity = 0.80;
			this.BackColor = SystemColors.Control;
			this.timerPreview.Stop();
		}

		#endregion Methods

		#region Handlers

		private void timerPreview_Tick(object sender, EventArgs e)
		{
			if (!this.isHovering)
			{
				this.notifierOwner.DisplayNotifications();
			}
		}

		private void NotifyMessage_MouseClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
				{
					if (this.link != null && this.link.IsAbsoluteUri)
					{
						BrowserUtility.LaunchBrowser(this.link);
					}
					break;
				}
				case MouseButtons.Right:
				{
					this.TimerStop();
					break;
				}
			}
		}

		private void textBody_MouseClick(object sender, MouseEventArgs e)
		{
			this.NotifyMessage_MouseClick(sender, e);
		}

		private void NotifyMessage_MouseEnter(object sender, EventArgs e)
		{
			this.isHovering = true;
			this.BackColor = SystemColors.Info;
			this.Opacity = 1.00;
		}

		private void NotifyMessage_MouseLeave(object sender, EventArgs e)
		{
			this.isHovering = false;
			this.BackColor = SystemColors.Control;
			this.Opacity = 0.80;
		}

		private void NotifyMessage_VisibleChanged(object sender, EventArgs e)
		{
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			this.Location = new Point(workingArea.Left+4, workingArea.Bottom-this.Height-4);
		}

		#endregion Handlers
	}
}