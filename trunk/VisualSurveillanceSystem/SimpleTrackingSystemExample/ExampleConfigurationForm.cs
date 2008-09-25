using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem
{
	public partial class ExampleConfigurationForm : ConfigurationForm
	{
		public ExampleConfigurationForm()
		{
			InitializeComponent();
			// Default value must be set.
			args.Add("Threshold", (byte)40);
		}

		/// <summary>
		/// This are the arguments.
		/// </summary>
		private IDictionary<string, object> args = new Dictionary<string, object>();
		
		/// <summary>
		/// Gets configuration as supplied by the user using this form.
		/// This configuration will be later used by a tracking system.
		/// </summary>
		/// <returns>A dictionary of configuration options.</returns>
		public override IDictionary<string, object> GetConfiguration()
		{
			return args;
		}

		/// <summary>
		/// Handles the Click event of the btnOk control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			// Check that values are correct.
			byte threshold;
			if (Byte.TryParse(txtThreshold.Text, out threshold))
			{
				args.Clear();
				args.Add("Threshold", threshold);
				this.DialogResult = DialogResult.OK;
				// Result is OK
				Hide();
			} else
			{
				// Indicate an error.
				MessageBox.Show(this, "Values nust be between 0 and 255.", "Invalid Input",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtThreshold.Text = args["Threshold"].ToString();
		}

		private void ExampleConfigurationForm_Load(object sender, EventArgs e)
		{

		}
	}
}

