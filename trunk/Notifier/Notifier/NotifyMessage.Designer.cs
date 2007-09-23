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
			this.lblBody = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(13, 13);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(60, 17);
			this.lblCount.TabIndex = 0;
			this.lblCount.Text = "00 of 00";
			// 
			// lblAuthor
			// 
			this.lblAuthor.AutoSize = true;
			this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.Location = new System.Drawing.Point(79, 13);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(327, 17);
			this.lblAuthor.TabIndex = 0;
			this.lblAuthor.Text = "FirstName LastName <email@example.com>";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(13, 30);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(377, 17);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "RE: The quick brown fox jumped over the lazy dog.";
			// 
			// lblBody
			// 
			this.lblBody.AutoSize = true;
			this.lblBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBody.Location = new System.Drawing.Point(13, 47);
			this.lblBody.Name = "lblBody";
			this.lblBody.Size = new System.Drawing.Size(785, 17);
			this.lblBody.TabIndex = 0;
			this.lblBody.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i" +
    "ncididunt ut labore et dolore magna aliqua.";
			// 
			// NotifyMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 78);
			this.ControlBox = false;
			this.Controls.Add(this.lblBody);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblAuthor);
			this.Controls.Add(this.lblCount);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NotifyMessage";
			this.Opacity = 0.9;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NotifyMessage";
			this.TopMost = true;
			this.Click += new System.EventHandler(this.NotifyMessage_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblBody;
	}
}