using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem
{
	public partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets configuration as supplied by the user using this form.
		/// This configuration will be later used by a tracking system.
		/// </summary>
		/// <returns>A dictionary of configuration options.</returns>
		public virtual IDictionary<string, object> GetConfiguration()
		{
			throw new NotImplementedException();
		}
	}
}