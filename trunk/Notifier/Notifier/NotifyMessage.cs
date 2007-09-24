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

		private Uri link = null;

		#endregion Fields

		#region Init

		public NotifyMessage()
		{
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

		#endregion Methods

		#region Handlers

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

		#endregion Handlers
	}
}