namespace Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem
{
	partial class ExampleRuntimeInformationForm
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
			this.imgMotion = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgMotion)).BeginInit();
			this.SuspendLayout();
			// 
			// imgMotion
			// 
			this.imgMotion.BackColor = System.Drawing.Color.Black;
			this.imgMotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgMotion.Location = new System.Drawing.Point(0, 0);
			this.imgMotion.Name = "imgMotion";
			this.imgMotion.Size = new System.Drawing.Size(292, 273);
			this.imgMotion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgMotion.TabIndex = 0;
			this.imgMotion.TabStop = false;
			// 
			// ExampleRuntimeInformationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.imgMotion);
			this.Name = "ExampleRuntimeInformationForm";
			this.Opacity = 0.7;
			this.ShowInTaskbar = false;
			this.Text = "Motion Segmentation Process";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExampleRuntimeInformationForm_FormClosed);
			this.Load += new System.EventHandler(this.ExampleRuntimeInformationForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.imgMotion)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imgMotion;
	}
}