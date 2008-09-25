using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.VFW;


namespace Zoombut.VisualSurveillanceSystem.Gui
{
	public partial class InputForm : Form
	{
		/// <summary>
		/// Video source chosen by user.
		/// </summary>
		private IVideoSource videoSource = null;
		/// <summary>
		/// Available camera inputs.
		/// </summary>
		private FilterInfoCollection filters;
		
		public InputForm()
		{
			InitializeComponent();
			// Disable panels at the beginning.
			pnlCamera.Enabled = false;
			pnlMjpeg.Enabled = false;
			pnlJpg.Enabled = false;
			try
			{
				filters = new FilterInfoCollection(FilterCategory.VideoInputDevice);

				if (filters.Count == 0)
					throw new ApplicationException();

				// add all devices to combo
				foreach (FilterInfo filter in filters)
				{
					deviceCombo.Items.Add(filter.Name);
				}
			}
			catch (ApplicationException)
			{
				deviceCombo.Items.Add("No local capture devices");
				deviceCombo.Enabled = false;
				rdoCaptureDevice.Enabled = false;
			}

			deviceCombo.SelectedIndex = 0;
		}



		/// <summary>
		/// Gets the video source chosen by the user.
		/// </summary>
		/// <value>The video source.Can be null if none was chosen.</value>
		public IVideoSource VideoSource
		{
			get { return videoSource; }
		}

		/// <summary>
		/// Handles the CheckedChanged event of the rdoCaptureDevice control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void rdoCaptureDevice_CheckedChanged(object sender, EventArgs e)
		{
			// Check if enabled.
			if (rdoCaptureDevice.Checked)
			{
				pnlAvi.Enabled = false;
				pnlMjpeg.Enabled = false;
				pnlCamera.Enabled = true;
				pnlJpg.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the rdoOpenMovieFile control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void rdoOpenMovieFile_CheckedChanged(object sender, EventArgs e)
		{
			// Check if enabled.
			if (rdoOpenMovieFile.Checked)
			{
				pnlAvi.Enabled = true;
				pnlMjpeg.Enabled = false;
				pnlCamera.Enabled = false;
				pnlJpg.Enabled = false;
			}
		}

		private void rdoMjpeg_CheckedChanged(object sender, EventArgs e)
		{
			// Check if enabled.
			if (rdoMjpeg.Checked)
			{
				pnlAvi.Enabled = false;
				pnlMjpeg.Enabled = true;
				pnlCamera.Enabled = false;
				pnlJpg.Enabled = false;
			}
		}

		private void rdoJpeg_CheckedChanged(object sender, EventArgs e)
		{
			// Check if enabled.
			if (rdoJpeg.Checked)
			{
				pnlAvi.Enabled = false;
				pnlMjpeg.Enabled = false;
				pnlCamera.Enabled = false;
				pnlJpg.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the Click event of the btnBrowse control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (openFile.ShowDialog() == DialogResult.OK)
			{
				txtFileName.Text = openFile.FileName;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// I'm making sure that filters actually contains something.
			if (rdoCaptureDevice.Checked && filters.Count > 0)
			// Chose to use a capture videoSource.
			{
				// create video source
				VideoCaptureDevice localSource = new VideoCaptureDevice();
				localSource.Source = filters[deviceCombo.SelectedIndex].MonikerString;
				localSource.DesiredFrameSize = new Size(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text));
				videoSource = localSource;
			}
			// Make sure that the text box contains a path.
			else if (!txtFileName.Text.Equals(String.Empty)) // Chose to load a movie.
			{
				// create video source
				AVIFileVideoSource fileSource = new AVIFileVideoSource();
				fileSource.Source = txtFileName.Text;
				videoSource = fileSource;
			} else if (!txtMjpegUrl.Text.Equals(String.Empty)) // Chose to load a url.
			{
				MJPEGStream stream = new MJPEGStream(txtMjpegUrl.Text);
				videoSource = stream;
			} else if (!txtJpgUrl.Text.Equals(String.Empty)) // Chose to load a url.
			{
				JPEGStream stream = new JPEGStream(txtJpgUrl.Text);
				videoSource = stream;
			}
			else // Unable to display.
			{
				showErrorMessage("No video source was chosen.");
				return;
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

		
	}
}