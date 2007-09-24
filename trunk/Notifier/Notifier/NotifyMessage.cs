using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Notifier.Providers;

namespace Notifier
{
	public partial class NotifyMessage : Form
	{
		public NotifyMessage()
		{
			InitializeComponent();
		}

		public void SetMessage(Notification msg)
		{
			this.lblCount.Visible = msg.Count > 0;
			this.lblDate.Visible = msg.Date != DateTime.MinValue;

			this.lblAuthor.Text = msg.Author;
			this.lblCount.Text = String.Format("{0} of {1}", msg.Index, msg.Count);
			this.lblTitle.Text = msg.Title;
			this.lblDate.Text = msg.Date.ToString("MMM dd, yyyy  HH:mm:ss");
			this.textBody.Text = msg.Body;
		}

		private void NotifyMessage_Click(object sender, EventArgs e)
		{
			//TODO: open browser to URL
		}
	}
}