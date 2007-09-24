namespace Notifier
{
	partial class NotifyMessage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyMessage));
			this.lblCount = new System.Windows.Forms.Label();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.textBody = new System.Windows.Forms.TextBox();
			this.lblDate = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCount.Location = new System.Drawing.Point(9, 9);
			this.lblCount.Margin = new System.Windows.Forms.Padding(0);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(44, 17);
			this.lblCount.TabIndex = 0;
			this.lblCount.Text = "0 of 0";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblAuthor
			// 
			this.lblAuthor.AutoSize = true;
			this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.Location = new System.Drawing.Point(56, 9);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(158, 17);
			this.lblAuthor.TabIndex = 0;
			this.lblAuthor.Text = "FirstName LastName";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(9, 26);
			this.lblTitle.MaximumSize = new System.Drawing.Size(357, 17);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(345, 17);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "RE: The quick brown fox jumped over the lazy dog.";
			// 
			// textBody
			// 
			this.textBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBody.Cursor = System.Windows.Forms.Cursors.Hand;
			this.textBody.Enabled = false;
			this.textBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBody.Location = new System.Drawing.Point(9, 43);
			this.textBody.Margin = new System.Windows.Forms.Padding(0);
			this.textBody.Multiline = true;
			this.textBody.Name = "textBody";
			this.textBody.ReadOnly = true;
			this.textBody.Size = new System.Drawing.Size(357, 38);
			this.textBody.TabIndex = 1;
			this.textBody.TabStop = false;
			this.textBody.Text = resources.GetString("textBody.Text");
			this.textBody.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBody_MouseClick);
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(213, 9);
			this.lblDate.MaximumSize = new System.Drawing.Size(153, 17);
			this.lblDate.MinimumSize = new System.Drawing.Size(153, 17);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(153, 17);
			this.lblDate.TabIndex = 0;
			this.lblDate.Text = "Dec 31, 9999 23:59:59";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// NotifyMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 78);
			this.ControlBox = false;
			this.Controls.Add(this.textBody);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblAuthor);
			this.Controls.Add(this.lblCount);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NotifyMessage";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NotifyMessage";
			this.TopMost = true;
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyMessage_MouseClick);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TextBox textBody;
		private System.Windows.Forms.Label lblDate;
	}
}