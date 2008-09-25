using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;

namespace Zoombut.SimpleFileOutputSystemExample
{
	public partial class FileConfigurationForm : ConfigurationForm
	{
		private IDictionary<string, object> returnValue =
			new Dictionary<string, object>();
		/// <summary>
		/// Cancel form close.
		/// </summary>
		private bool cancelClose;

		public FileConfigurationForm()
		{
			InitializeComponent();
			// Initialize returnValue with a default value.
			returnValue.Add("File",Directory.GetCurrentDirectory() + @"\output.csv");
			// Update txt box.
			txtFilePath.Text = returnValue["File"].ToString();
		}


		/// <summary>
		/// Gets configuration as supplied by the user using this form.
		/// This configuration will be later used by a tracking system.
		/// </summary>
		/// <returns>A dictionary of configuration options.</returns>
		public override IDictionary<string, object> GetConfiguration()
		{
			return returnValue;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// Check if user chose a file.
			if (!txtFilePath.Text.Equals(String.Empty))
			{
				returnValue["File"] = txtFilePath.Text;
				cancelClose = false;
			} else
			{
				cancelClose = true;
				MessageBox.Show(this, "Please choose a file name", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
		}

		private void FileConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (cancelClose)
			{
				e.Cancel = true;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				txtFilePath.Text = saveFile.FileName;
			}
		}
	}
}

