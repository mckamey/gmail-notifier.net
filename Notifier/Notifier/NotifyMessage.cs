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
			this.lblAuthor.Text = msg.Author;
			this.lblCount.Text = String.Format("{0} of {1}", msg.Index, msg.Count);
			this.lblTitle.Text = msg.Title;
			this.lblBody.Text = msg.Body;
		}

		private void NotifyMessage_Click(object sender, EventArgs e)
		{
			//TODO: open browser to URL
		}
	}
}