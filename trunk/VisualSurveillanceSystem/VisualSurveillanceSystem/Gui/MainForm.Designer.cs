

using Zoombut.VisualSurveillanceSystem.Controls;

namespace Zoombut.VisualSurveillanceLaboratory.Gui
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuConfigure = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.trackingSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuConfigureTrackingSystem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuShowRuntimeInformation = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trackingSystemToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(724, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConfigure,
            this.mnuStart,
            this.mnuStop,
            this.toolStripMenuItem1,
            this.mnuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// mnuConfigure
			// 
			this.mnuConfigure.Name = "mnuConfigure";
			this.mnuConfigure.Size = new System.Drawing.Size(133, 22);
			this.mnuConfigure.Text = "&Configure...";
			this.mnuConfigure.Click += new System.EventHandler(this.mnuOpenLocalDevice_Click);
			// 
			// mnuStart
			// 
			this.mnuStart.Enabled = false;
			this.mnuStart.Name = "mnuStart";
			this.mnuStart.Size = new System.Drawing.Size(133, 22);
			this.mnuStart.Text = "&Start...";
			this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
			// 
			// mnuStop
			// 
			this.mnuStop.Enabled = false;
			this.mnuStop.Name = "mnuStop";
			this.mnuStop.Size = new System.Drawing.Size(133, 22);
			this.mnuStop.Text = "St&op";
			this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(133, 22);
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// trackingSystemToolStripMenuItem
			// 
			this.trackingSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConfigureTrackingSystem,
            this.mnuShowRuntimeInformation});
			this.trackingSystemToolStripMenuItem.Name = "trackingSystemToolStripMenuItem";
			this.trackingSystemToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.trackingSystemToolStripMenuItem.Text = "&Options";
			// 
			// mnuConfigureTrackingSystem
			// 
			this.mnuConfigureTrackingSystem.Enabled = false;
			this.mnuConfigureTrackingSystem.Name = "mnuConfigureTrackingSystem";
			this.mnuConfigureTrackingSystem.Size = new System.Drawing.Size(231, 22);
			this.mnuConfigureTrackingSystem.Text = "Configure &Surveillance System...";
			// 
			// mnuShowRuntimeInformation
			// 
			this.mnuShowRuntimeInformation.Enabled = false;
			this.mnuShowRuntimeInformation.Name = "mnuShowRuntimeInformation";
			this.mnuShowRuntimeInformation.Size = new System.Drawing.Size(231, 22);
			this.mnuShowRuntimeInformation.Text = "&Show Runtime Information";
			this.mnuShowRuntimeInformation.Click += new System.EventHandler(this.mnuShowRuntimeInformation_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Name = "mnuAbout";
			this.mnuAbout.Size = new System.Drawing.Size(103, 22);
			this.mnuAbout.Text = "&About";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// openFile
			// 
			this.openFile.Filter = "Avi files|*.avi";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(724, 249);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 273);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Visual Surveillance Laboratory ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuConfigure;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.ToolStripMenuItem trackingSystemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuConfigureTrackingSystem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuAbout;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.ToolStripMenuItem mnuShowRuntimeInformation;
		private System.Windows.Forms.ToolStripMenuItem mnuStart;
		private System.Windows.Forms.ToolStripMenuItem mnuStop;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

