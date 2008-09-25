using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;
using Zoombut.VisualSurveillanceSystem.Controls;

namespace Zoombut.VisualSurveillanceLaboratory.Gui
{
	public partial class MainForm : Form
	{
		
		/// <summary>
		/// Start running the tracking.
		/// </summary>
		private CaptureDeviceForm captureDeviceForm = new CaptureDeviceForm();
		/// <summary>
		/// The tracking system chosen by the user.
		/// </summary>
		private ISurveillanceSystem surveillanceSystem;
		/// <summary>
		/// Form used to display runtime information.
		/// </summary>
		private Form runtimeForm;

		/// <summary>
		/// Camera that receives source input and displays it on screen.
		/// </summary>
		private Camera camera;
		/// <summary>
		/// Output system chosen by the user.
		/// </summary>
		private IOutput outputSystem;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles the Click event of the mnuOpenLocalDevice control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuOpenLocalDevice_Click(object sender, EventArgs e)
		{
			// Stop running when showing the configuration box.
			if (camera != null)
			{
				camera.Stop();
			}

			if (captureDeviceForm.ShowDialog(this) == DialogResult.OK)
			{
				// Clean previous data.
				Clean();

				IVideoSource source = captureDeviceForm.Device;
				
				// Update tracking system.
				surveillanceSystem = captureDeviceForm.Surveillance;
				// Update output system.
				outputSystem = captureDeviceForm.Output.GetOutput(captureDeviceForm.OutputConfiguration);

				// Check if you can display Runtime information.
				if (surveillanceSystem.HasRuntimeInformation)
				{
					mnuShowRuntimeInformation.Enabled = true;
				}
				// Can it be configured during runtime.
				if (surveillanceSystem.IsRuntimeConfigurable)
				{
					mnuConfigureTrackingSystem.Enabled = true;
				}
				// open it
				OpenVideoSource(source, surveillanceSystem, captureDeviceForm.TrackingConfiguration, outputSystem);
				mnuStart.Enabled = true;

			}
		}

		/// <summary>
		/// Opens the video source and prepares the surveillance system.
		/// </summary>
		/// <param name="source">The video source.</param>
		/// <param name="surveillance">The surveillance system.</param>
		/// <param name="conf">The configuration for the image process.</param>
		/// <param name="output">The output.</param>
		private void OpenVideoSource(IVideoSource source, ISurveillanceSystem surveillance, IDictionary<string, object> conf, IOutput output)
		{
			// set busy cursor
			Cursor = Cursors.WaitCursor;
			// create camera
			camera = new Camera(source, surveillance.GetImageProcess(conf), output, surveillance.GraphicalOutput, pictureBox1);
			Cursor = Cursors.Default;
		}


		/// <summary>
		/// Cleans this instance by closing unused resources like camera.
		/// </summary>
		private void Clean()
		{
			if (camera != null)
			{
				// detach camera from camera window
				//cameraWindow.Camera = null;

				// signal camera to stop
				camera.SignalToStop();
				// wait for the camera
				camera.WaitForStop();

				camera = null;
			}

			if (outputSystem != null)
			{
				outputSystem.Close();
			}

			if (surveillanceSystem != null)
			{
				surveillanceSystem.Close();
			}
		}

		/// <summary>
		/// Handles the FormClosing event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Clean();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void mnuAbout_Click(object sender, EventArgs e)
		{
			AboutBox form = new AboutBox();
			form.ShowDialog();
		}

		private void mnuShowRuntimeInformation_Click(object sender, EventArgs e)
		{
			runtimeForm = surveillanceSystem.RuntimeInformation;
			runtimeForm.Closed += new EventHandler(runtimeFormClosed);
			mnuShowRuntimeInformation.Enabled = false;
			runtimeForm.Show();
		}

		/// <summary>
		/// Runtime form was closed.
		/// Dispose the form.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void runtimeFormClosed(object sender, EventArgs e)
		{
			runtimeForm.Dispose();
			mnuShowRuntimeInformation.Enabled = true;
		}

		private void mnuStart_Click(object sender, EventArgs e)
		{
			camera.Start();
			// Toggle menu choice.
			mnuStop.Enabled = true;
			mnuStart.Enabled = false;
		}

		private void mnuStop_Click(object sender, EventArgs e)
		{
			camera.Stop();
			// Toggle menu choice.
			mnuStop.Enabled = false;
			mnuStart.Enabled = true;
		}

		
	}
}