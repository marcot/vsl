using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Video;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;
using Zoombut.VisualSurveillanceSystem.Gui;

namespace Zoombut.VisualSurveillanceLaboratory.Gui
{
	/// <summary>
	/// Summary description for CaptureDeviceForm.
	/// </summary>
	public class CaptureDeviceForm : Form
	{
		#region Private variables.

		
		private Button cancelButton;
		private Button okButton;
		private IVideoSource videoSource;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private TextBox txtTrackingDescription;
		private Label label2;
		private Label label1;
		private ComboBox cmbAvailableTrackingSystems;
		private Button btnConfigureTrackingSystem;
		private GroupBox groupBox3;
		private TextBox txtOutputDescription;
		private Label label4;
		private Button btnConfigureOutput;
		private Label label3;
		private ComboBox cmbAvailableOutputSystems;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// What is the surveillance system the user chose.
		/// </summary>
		private ISurveillanceSystem surveillance;
		/// <summary>
		/// Holds the configuration as chosen by the user.
		/// </summary>
		private IDictionary<string, object> trackingConfiguration = null;
		/// <summary>
		/// Holds the configuration as chosen by the user.
		/// </summary>
		private IDictionary<string, object> outputConfiguration = null;

		/// <summary>
		/// Surveillance systems loaded by the factory.
		/// </summary>
		private IList<ISurveillanceSystem> foundTrackingSystems = TrackingSystemsFactory.GetInstance().AvailableTrackingSystems;

		private IList<IOutputSystem> foundOutputSystems =
			OutputSystemFactory.GetInstance().AvailableOutputSystems;
		/// <summary>
		/// Surveillance Configuration form of a surveillance system.
		/// </summary>
		private ConfigurationForm trackingConfigForm = null;
		/// <summary>
		/// Surveillance Configuration form of a output system.
		/// </summary>
		private ConfigurationForm outputConfigForm = null;
		private Button btnChooseSource;
		private TextBox txtSource;
		/// <summary>
		/// What is the output system the user chose.
		/// </summary>
		private IOutputSystem output;

		#endregion


		#region Properties



		/// <summary>
		/// Gets the surveillance configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public IDictionary<string, object> TrackingConfiguration
		{
			get { return trackingConfiguration; }
		}


		/// <summary>
		/// Gets the output configuration.
		/// </summary>
		/// <value>The output configuration.</value>
		public IDictionary<string, object> OutputConfiguration
		{
			get { return outputConfiguration; }
		}

		/// <summary>
		/// Gets the output system chosen by the user.
		/// </summary>
		/// <value>The output.</value>
		public IOutputSystem Output
		{
			get { return output; }
		}

		/// <summary>
		/// Gets the device the acts as video source.
		/// </summary>
		/// <value>The device.</value>
		public IVideoSource Device
		{
			get { return videoSource; }
		}

		/// <summary>
		/// Gets the surveillance system chose by the user.
		/// </summary>
		/// <value>The surveillance system.</value>
		public ISurveillanceSystem Surveillance
		{
			get { return surveillance; }
		}

		#endregion

 
		// Constructor
		public CaptureDeviceForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnChooseSource = new System.Windows.Forms.Button();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnConfigureTrackingSystem = new System.Windows.Forms.Button();
			this.txtTrackingDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbAvailableTrackingSystems = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtOutputDescription = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnConfigureOutput = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbAvailableOutputSystems = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(351, 408);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Cancel";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(270, 408);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "Ok";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnChooseSource);
			this.groupBox1.Controls.Add(this.txtSource);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(414, 47);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input";
			// 
			// btnChooseSource
			// 
			this.btnChooseSource.Location = new System.Drawing.Point(333, 17);
			this.btnChooseSource.Name = "btnChooseSource";
			this.btnChooseSource.Size = new System.Drawing.Size(75, 23);
			this.btnChooseSource.TabIndex = 1;
			this.btnChooseSource.Text = "Source...";
			this.btnChooseSource.UseVisualStyleBackColor = true;
			this.btnChooseSource.Click += new System.EventHandler(this.btnChooseSource_Click);
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(9, 19);
			this.txtSource.Name = "txtSource";
			this.txtSource.ReadOnly = true;
			this.txtSource.Size = new System.Drawing.Size(318, 20);
			this.txtSource.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnConfigureTrackingSystem);
			this.groupBox2.Controls.Add(this.txtTrackingDescription);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.cmbAvailableTrackingSystems);
			this.groupBox2.Location = new System.Drawing.Point(12, 65);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(414, 161);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Surveillance Systems";
			// 
			// btnConfigureTrackingSystem
			// 
			this.btnConfigureTrackingSystem.Location = new System.Drawing.Point(333, 30);
			this.btnConfigureTrackingSystem.Name = "btnConfigureTrackingSystem";
			this.btnConfigureTrackingSystem.Size = new System.Drawing.Size(75, 23);
			this.btnConfigureTrackingSystem.TabIndex = 4;
			this.btnConfigureTrackingSystem.Text = "Configure...";
			this.btnConfigureTrackingSystem.UseVisualStyleBackColor = true;
			this.btnConfigureTrackingSystem.Click += new System.EventHandler(this.btnConfigureTrackingSystem_Click);
			// 
			// txtTrackingDescription
			// 
			this.txtTrackingDescription.Location = new System.Drawing.Point(9, 82);
			this.txtTrackingDescription.Multiline = true;
			this.txtTrackingDescription.Name = "txtTrackingDescription";
			this.txtTrackingDescription.ReadOnly = true;
			this.txtTrackingDescription.Size = new System.Drawing.Size(318, 73);
			this.txtTrackingDescription.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available surveillance systems:";
			// 
			// cmbAvailableTrackingSystems
			// 
			this.cmbAvailableTrackingSystems.DisplayMember = "Name";
			this.cmbAvailableTrackingSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvailableTrackingSystems.FormattingEnabled = true;
			this.cmbAvailableTrackingSystems.Location = new System.Drawing.Point(9, 32);
			this.cmbAvailableTrackingSystems.Name = "cmbAvailableTrackingSystems";
			this.cmbAvailableTrackingSystems.Size = new System.Drawing.Size(318, 21);
			this.cmbAvailableTrackingSystems.TabIndex = 0;
			this.cmbAvailableTrackingSystems.SelectedIndexChanged += new System.EventHandler(this.cmbAvailableTrackingSystems_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtOutputDescription);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.btnConfigureOutput);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.cmbAvailableOutputSystems);
			this.groupBox3.Location = new System.Drawing.Point(12, 232);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(414, 170);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Output System";
			// 
			// txtOutputDescription
			// 
			this.txtOutputDescription.Location = new System.Drawing.Point(9, 83);
			this.txtOutputDescription.Multiline = true;
			this.txtOutputDescription.Name = "txtOutputDescription";
			this.txtOutputDescription.ReadOnly = true;
			this.txtOutputDescription.Size = new System.Drawing.Size(318, 73);
			this.txtOutputDescription.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Description:";
			// 
			// btnConfigureOutput
			// 
			this.btnConfigureOutput.Location = new System.Drawing.Point(333, 30);
			this.btnConfigureOutput.Name = "btnConfigureOutput";
			this.btnConfigureOutput.Size = new System.Drawing.Size(75, 23);
			this.btnConfigureOutput.TabIndex = 7;
			this.btnConfigureOutput.Text = "Configure...";
			this.btnConfigureOutput.UseVisualStyleBackColor = true;
			this.btnConfigureOutput.Click += new System.EventHandler(this.btnConfigureOutput_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Available output systems:";
			// 
			// cmbAvailableOutputSystems
			// 
			this.cmbAvailableOutputSystems.DisplayMember = "Name";
			this.cmbAvailableOutputSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvailableOutputSystems.FormattingEnabled = true;
			this.cmbAvailableOutputSystems.Location = new System.Drawing.Point(9, 32);
			this.cmbAvailableOutputSystems.Name = "cmbAvailableOutputSystems";
			this.cmbAvailableOutputSystems.Size = new System.Drawing.Size(318, 21);
			this.cmbAvailableOutputSystems.TabIndex = 5;
			this.cmbAvailableOutputSystems.SelectedIndexChanged += new System.EventHandler(this.cmbAvailableOutputSystems_SelectedIndexChanged);
			// 
			// CaptureDeviceForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(438, 438);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CaptureDeviceForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configure";
			this.Load += new System.EventHandler(this.CaptureDeviceForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		#region Events

		private void cmbAvailableOutputSystems_SelectedIndexChanged(object sender, EventArgs e)
		{
			updateOutputSystemGui();
		}

		private void btnConfigureOutput_Click(object sender, EventArgs e)
		{
			// Just to be sure.
			if (output.IsConfigurable)
			{
				if (outputConfigForm.ShowDialog() == DialogResult.OK)
				{
					outputConfiguration = outputConfigForm.GetConfiguration();
				}
			}
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the cmbAvailableTrackingSystems control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void cmbAvailableTrackingSystems_SelectedIndexChanged(object sender, EventArgs e)
		{
			updateTrackingSystemGui();
		}

		/// <summary>
		/// Handles the Click event of the btnConfigureTrackingSystem control.
		/// Shows configuration form.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnConfigureTrackingSystem_Click(object sender, EventArgs e)
		{
			// Just to be sure.
			if (trackingConfigForm != null)
			{
				if (trackingConfigForm.ShowDialog() == DialogResult.OK)
				{
					trackingConfiguration = trackingConfigForm.GetConfiguration();
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void okButton_Click(object sender, EventArgs e)
		{
			// Make sure that the user chose surveillance and output systems.
			if (foundTrackingSystems.Count == 0 || foundOutputSystems.Count == 0)
			{
				showErrorMessage("No surveillance systems were found.Please check you configuration file.");
				return;
			}
			else
			{
				// Next retrieve the surveillance  and output systems.
				surveillance =
					foundTrackingSystems[cmbAvailableTrackingSystems.SelectedIndex];
				output = foundOutputSystems[cmbAvailableOutputSystems.SelectedIndex];
				// Check that the user chose a video source.
				if (videoSource == null)
				{
					showErrorMessage("No viseo source was chosen.");
					return;
				}
			}

			DialogResult = DialogResult.OK;
			Hide();
			
		}

		/// <summary>
		/// Shows an error message box.
		/// </summary>
		/// <param name="message">The message to display.</param>
		private void showErrorMessage(string message)
		{
			MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		


		private void CaptureDeviceForm_Load(object sender, EventArgs e)
		{
			// Can not run without a tracker.
			if (foundTrackingSystems.Count == 0 || foundOutputSystems.Count == 0)
			{
				okButton.Enabled = false;
			}
			else // Populate surveillance system combo box.
			{
				foreach (ISurveillanceSystem system in foundTrackingSystems)
				{
					cmbAvailableTrackingSystems.Items.Add(system);
				}
				cmbAvailableTrackingSystems.SelectedIndex = 0;

				foreach (IOutputSystem system in foundOutputSystems)
				{
					cmbAvailableOutputSystems.Items.Add(system);
				}
				cmbAvailableOutputSystems.SelectedIndex = 0;
			}
		}


		#endregion

		#region Utility methods

		/// <summary>
		/// Updates the configure button, description box and surveillance variable.
		/// If the surveillance system chosen can be configured then enable it,
		/// otherwise disable it.
		/// </summary>
		private void updateTrackingSystemGui()
		{
			surveillance = foundTrackingSystems[cmbAvailableTrackingSystems.SelectedIndex];
			// Update configuration options.
			if (surveillance.IsConfigurable)
			{
				// Dispose old one.
				if (trackingConfigForm != null)
				{
					trackingConfigForm.Dispose();
				}
				trackingConfigForm = surveillance.ConfigurationForm;
				// Get default configuration.
				trackingConfiguration = trackingConfigForm.GetConfiguration();
			}
			btnConfigureTrackingSystem.Enabled = surveillance.IsConfigurable;
			txtTrackingDescription.Text = surveillance.Description;
		}

		/// <summary>
		/// Updates the configure button, description box and output variable.
		/// If the out system chosen can be configured then enable it,
		/// otherwise disable it.
		/// </summary>
		private void updateOutputSystemGui()
		{
			output = foundOutputSystems[cmbAvailableOutputSystems.SelectedIndex];
			// Update configuration options.
			if (output.IsConfigurable)
			{
				// Dispose old one.
				if (outputConfigForm != null)
				{
					outputConfigForm.Dispose();
				}
				outputConfigForm = output.ConfigurationForm;
				// Get default configuration.
				outputConfiguration = outputConfigForm.GetConfiguration();
			}
			btnConfigureOutput.Enabled = output.IsConfigurable;
			txtOutputDescription.Text = output.Description;
		}

		#endregion

		private void btnChooseSource_Click(object sender, EventArgs e)
		{
			InputForm inputForm = new InputForm();
			if (inputForm.ShowDialog() == DialogResult.OK)
			{
				// Get IVIdeoSource object.
				videoSource = inputForm.VideoSource;
				txtSource.Text = videoSource.Source;
			}

			inputForm.Dispose();
		}
	}
}
