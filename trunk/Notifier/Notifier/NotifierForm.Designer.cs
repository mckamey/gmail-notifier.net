namespace Notifier
{
	partial class NotifierForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifierForm));
			this.theNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.theContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textUsername = new System.Windows.Forms.TextBox();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.timerPolling = new System.Windows.Forms.Timer(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.panelBtns = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.timerPreview = new System.Windows.Forms.Timer(this.components);
			this.theContextMenuStrip.SuspendLayout();
			this.panelBtns.SuspendLayout();
			this.SuspendLayout();
			// 
			// theNotifyIcon
			// 
			this.theNotifyIcon.ContextMenuStrip = this.theContextMenuStrip;
			this.theNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("theNotifyIcon.Icon")));
			this.theNotifyIcon.Text = "Notifier";
			this.theNotifyIcon.Visible = true;
			this.theNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.theNotifyIcon_MouseDoubleClick);
			// 
			// theContextMenuStrip
			// 
			this.theContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.separator1,
            this.quitToolStripMenuItem});
			this.theContextMenuStrip.Name = "theContextMenuStrip";
			this.theContextMenuStrip.Size = new System.Drawing.Size(124, 76);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// updateToolStripMenuItem
			// 
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.updateToolStripMenuItem.Text = "Update";
			this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(120, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// textUsername
			// 
			this.textUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textUsername.Dock = System.Windows.Forms.DockStyle.Top;
			this.textUsername.Location = new System.Drawing.Point(8, 8);
			this.textUsername.Name = "textUsername";
			this.textUsername.Size = new System.Drawing.Size(276, 22);
			this.textUsername.TabIndex = 1;
			this.textUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NotifierForm_KeyPress);
			// 
			// textPassword
			// 
			this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textPassword.Dock = System.Windows.Forms.DockStyle.Top;
			this.textPassword.Location = new System.Drawing.Point(8, 30);
			this.textPassword.Name = "textPassword";
			this.textPassword.PasswordChar = '*';
			this.textPassword.Size = new System.Drawing.Size(276, 22);
			this.textPassword.TabIndex = 2;
			this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NotifierForm_KeyPress);
			// 
			// timerPolling
			// 
			this.timerPolling.Interval = 300000;
			this.timerPolling.Tick += new System.EventHandler(this.timerPolling_Tick);
			// 
			// btnCancel
			// 
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(141, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(135, 29);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panelBtns
			// 
			this.panelBtns.Controls.Add(this.btnOK);
			this.panelBtns.Controls.Add(this.btnCancel);
			this.panelBtns.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelBtns.Location = new System.Drawing.Point(8, 52);
			this.panelBtns.Name = "panelBtns";
			this.panelBtns.Size = new System.Drawing.Size(276, 29);
			this.panelBtns.TabIndex = 5;
			// 
			// btnOK
			// 
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnOK.Location = new System.Drawing.Point(0, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(135, 29);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// timerPreview
			// 
			this.timerPreview.Interval = 3000;
			this.timerPreview.Tick += new System.EventHandler(this.timerPreview_Tick);
			// 
			// NotifierForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 89);
			this.ControlBox = false;
			this.Controls.Add(this.panelBtns);
			this.Controls.Add(this.textPassword);
			this.Controls.Add(this.textUsername);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(50, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NotifierForm";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Notifier";
			this.TopMost = true;
			this.Resize += new System.EventHandler(this.NotifierForm_Resize);
			this.VisibleChanged += new System.EventHandler(this.NotifierForm_VisibleChanged);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NotifierForm_KeyPress);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotifierForm_FormClosing);
			this.theContextMenuStrip.ResumeLayout(false);
			this.panelBtns.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon theNotifyIcon;
		private System.Windows.Forms.ContextMenuStrip theContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.TextBox textUsername;
		private System.Windows.Forms.TextBox textPassword;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.Timer timerPolling;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panelBtns;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Timer timerPreview;
	}
}

