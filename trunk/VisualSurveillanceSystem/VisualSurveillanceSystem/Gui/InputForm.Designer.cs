namespace Zoombut.VisualSurveillanceSystem.Gui
{
	partial class InputForm
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
			this.rdoOpenMovieFile = new System.Windows.Forms.RadioButton();
			this.rdoMjpeg = new System.Windows.Forms.RadioButton();
			this.txtMjpegUrl = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.pnlCamera = new System.Windows.Forms.Panel();
			this.deviceCombo = new System.Windows.Forms.ComboBox();
			this.rdoCaptureDevice = new System.Windows.Forms.RadioButton();
			this.pnlAvi = new System.Windows.Forms.Panel();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.pnlMjpeg = new System.Windows.Forms.Panel();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.rdoJpeg = new System.Windows.Forms.RadioButton();
			this.pnlJpg = new System.Windows.Forms.Panel();
			this.txtJpgUrl = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.pnlCamera.SuspendLayout();
			this.pnlAvi.SuspendLayout();
			this.pnlMjpeg.SuspendLayout();
			this.pnlJpg.SuspendLayout();
			this.SuspendLayout();
			// 
			// rdoOpenMovieFile
			// 
			this.rdoOpenMovieFile.AutoSize = true;
			this.rdoOpenMovieFile.Checked = true;
			this.rdoOpenMovieFile.Location = new System.Drawing.Point(12, 95);
			this.rdoOpenMovieFile.Name = "rdoOpenMovieFile";
			this.rdoOpenMovieFile.Size = new System.Drawing.Size(101, 17);
			this.rdoOpenMovieFile.TabIndex = 15;
			this.rdoOpenMovieFile.TabStop = true;
			this.rdoOpenMovieFile.Text = "Open movie file:";
			this.rdoOpenMovieFile.UseVisualStyleBackColor = true;
			this.rdoOpenMovieFile.CheckedChanged += new System.EventHandler(this.rdoOpenMovieFile_CheckedChanged);
			// 
			// rdoMjpeg
			// 
			this.rdoMjpeg.AutoSize = true;
			this.rdoMjpeg.Location = new System.Drawing.Point(12, 153);
			this.rdoMjpeg.Name = "rdoMjpeg";
			this.rdoMjpeg.Size = new System.Drawing.Size(112, 17);
			this.rdoMjpeg.TabIndex = 18;
			this.rdoMjpeg.TabStop = true;
			this.rdoMjpeg.Text = "Motion JPEG URL";
			this.rdoMjpeg.UseVisualStyleBackColor = true;
			this.rdoMjpeg.CheckedChanged += new System.EventHandler(this.rdoMjpeg_CheckedChanged);
			// 
			// txtMjpegUrl
			// 
			this.txtMjpegUrl.Location = new System.Drawing.Point(3, 3);
			this.txtMjpegUrl.Name = "txtMjpegUrl";
			this.txtMjpegUrl.Size = new System.Drawing.Size(401, 20);
			this.txtMjpegUrl.TabIndex = 19;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(341, 286);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(260, 286);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 21;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// pnlCamera
			// 
			this.pnlCamera.Controls.Add(this.label2);
			this.pnlCamera.Controls.Add(this.label1);
			this.pnlCamera.Controls.Add(this.txtHeight);
			this.pnlCamera.Controls.Add(this.txtWidth);
			this.pnlCamera.Controls.Add(this.deviceCombo);
			this.pnlCamera.Location = new System.Drawing.Point(12, 34);
			this.pnlCamera.Name = "pnlCamera";
			this.pnlCamera.Size = new System.Drawing.Size(412, 55);
			this.pnlCamera.TabIndex = 22;
			// 
			// deviceCombo
			// 
			this.deviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.deviceCombo.Location = new System.Drawing.Point(3, 3);
			this.deviceCombo.Name = "deviceCombo";
			this.deviceCombo.Size = new System.Drawing.Size(401, 21);
			this.deviceCombo.TabIndex = 15;
			// 
			// rdoCaptureDevice
			// 
			this.rdoCaptureDevice.AutoSize = true;
			this.rdoCaptureDevice.Location = new System.Drawing.Point(12, 11);
			this.rdoCaptureDevice.Name = "rdoCaptureDevice";
			this.rdoCaptureDevice.Size = new System.Drawing.Size(163, 17);
			this.rdoCaptureDevice.TabIndex = 16;
			this.rdoCaptureDevice.Text = "Select capture video Source:";
			this.rdoCaptureDevice.UseVisualStyleBackColor = true;
			this.rdoCaptureDevice.CheckedChanged += new System.EventHandler(this.rdoCaptureDevice_CheckedChanged);
			// 
			// pnlAvi
			// 
			this.pnlAvi.Controls.Add(this.btnBrowse);
			this.pnlAvi.Controls.Add(this.txtFileName);
			this.pnlAvi.Location = new System.Drawing.Point(12, 116);
			this.pnlAvi.Name = "pnlAvi";
			this.pnlAvi.Size = new System.Drawing.Size(412, 31);
			this.pnlAvi.TabIndex = 23;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(329, 3);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 19;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(3, 5);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.ReadOnly = true;
			this.txtFileName.Size = new System.Drawing.Size(318, 20);
			this.txtFileName.TabIndex = 18;
			// 
			// pnlMjpeg
			// 
			this.pnlMjpeg.Controls.Add(this.txtMjpegUrl);
			this.pnlMjpeg.Location = new System.Drawing.Point(12, 176);
			this.pnlMjpeg.Name = "pnlMjpeg";
			this.pnlMjpeg.Size = new System.Drawing.Size(412, 30);
			this.pnlMjpeg.TabIndex = 24;
			// 
			// openFile
			// 
			this.openFile.Filter = "Avi Files|*.avi";
			// 
			// rdoJpeg
			// 
			this.rdoJpeg.AutoSize = true;
			this.rdoJpeg.Location = new System.Drawing.Point(12, 212);
			this.rdoJpeg.Name = "rdoJpeg";
			this.rdoJpeg.Size = new System.Drawing.Size(112, 17);
			this.rdoJpeg.TabIndex = 27;
			this.rdoJpeg.TabStop = true;
			this.rdoJpeg.Text = "Motion JPEG URL";
			this.rdoJpeg.UseVisualStyleBackColor = true;
			this.rdoJpeg.CheckedChanged += new System.EventHandler(this.rdoJpeg_CheckedChanged);
			// 
			// pnlJpg
			// 
			this.pnlJpg.Controls.Add(this.txtJpgUrl);
			this.pnlJpg.Enabled = false;
			this.pnlJpg.Location = new System.Drawing.Point(12, 235);
			this.pnlJpg.Name = "pnlJpg";
			this.pnlJpg.Size = new System.Drawing.Size(412, 30);
			this.pnlJpg.TabIndex = 28;
			// 
			// txtJpgUrl
			// 
			this.txtJpgUrl.Location = new System.Drawing.Point(3, 3);
			this.txtJpgUrl.Name = "txtJpgUrl";
			this.txtJpgUrl.Size = new System.Drawing.Size(401, 20);
			this.txtJpgUrl.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(152, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 29;
			this.label2.Text = "Height";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 30;
			this.label1.Text = "Width";
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(193, 30);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(100, 20);
			this.txtHeight.TabIndex = 27;
			this.txtHeight.Text = "240";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(46, 30);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(100, 20);
			this.txtWidth.TabIndex = 28;
			this.txtWidth.Text = "320";
			// 
			// InputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 316);
			this.ControlBox = false;
			this.Controls.Add(this.rdoJpeg);
			this.Controls.Add(this.pnlJpg);
			this.Controls.Add(this.rdoCaptureDevice);
			this.Controls.Add(this.rdoMjpeg);
			this.Controls.Add(this.pnlMjpeg);
			this.Controls.Add(this.rdoOpenMovieFile);
			this.Controls.Add(this.pnlAvi);
			this.Controls.Add(this.pnlCamera);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "InputForm";
			this.Text = "Input";
			this.pnlCamera.ResumeLayout(false);
			this.pnlCamera.PerformLayout();
			this.pnlAvi.ResumeLayout(false);
			this.pnlAvi.PerformLayout();
			this.pnlMjpeg.ResumeLayout(false);
			this.pnlMjpeg.PerformLayout();
			this.pnlJpg.ResumeLayout(false);
			this.pnlJpg.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rdoOpenMovieFile;
		private System.Windows.Forms.RadioButton rdoMjpeg;
		private System.Windows.Forms.TextBox txtMjpegUrl;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel pnlCamera;
		private System.Windows.Forms.RadioButton rdoCaptureDevice;
		private System.Windows.Forms.ComboBox deviceCombo;
		private System.Windows.Forms.Panel pnlAvi;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Panel pnlMjpeg;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.RadioButton rdoJpeg;
		private System.Windows.Forms.Panel pnlJpg;
		private System.Windows.Forms.TextBox txtJpgUrl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.TextBox txtWidth;
	}
}