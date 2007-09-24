using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
			this.lblDate.Visible = msg.Date != DateTime.MinValue;

			this.lblAuthor.Text = msg.Author;
			this.lblCount.Text = String.Format("{0} of {1}", msg.Index, msg.Count);
			this.lblTitle.Text = msg.Title;
			this.lblDate.Text = msg.Date.ToString("MMM dd, yyyy @ HH:mm:ss");
			this.textBody.Text = msg.Body;
			this.link = msg.Link;
		}

		public void TimerStart()
		{
			this.isHovering = false;
			this.BackColor = SystemColors.Control;
			this.timerPreview.Start();
		}

		public void TimerStop()
		{
			this.isHovering = false;
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
			if (this.link != null && this.link.IsAbsoluteUri)
			{
				BrowserUtility.LaunchBrowser(this.link);
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
		}

		private void NotifyMessage_MouseLeave(object sender, EventArgs e)
		{
			this.isHovering = false;
			this.BackColor = SystemColors.Control;
		}

		#endregion Handlers
	}
}