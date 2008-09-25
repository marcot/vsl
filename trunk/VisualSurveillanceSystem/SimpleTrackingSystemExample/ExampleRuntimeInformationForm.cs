using System;
using System.Windows.Forms;
using Zoombut.SimpleTrackingSystemExample;

namespace Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem
{
	/// <summary>
	/// An example implementation of runtime information form.
	/// </summary>
	public partial class ExampleRuntimeInformationForm : Form
	{
		public ExampleRuntimeInformationForm()
		{
			InitializeComponent();
		}

		public void ImageChanged(Object sender, ImageChangedEventArgs e)
		{
			// Check that image is not null.
			if (e.Image != null)
			{
				imgMotion.Image = e.Image;
			}
		}

		private void ExampleRuntimeInformationForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}

		private void ExampleRuntimeInformationForm_Load(object sender, EventArgs e)
		{

		}
	}
}