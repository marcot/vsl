/*
 * Created by: Efi efi.merdler@gmail.com
 * Created: Monday, April 30, 2007
 */
using System;
using System.Collections.Generic;
using Zoombut.FileOutputSystem;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;

namespace Zoombut.SimpleFileOutputSystemExample
{
	public class ExampleOutputSystem : IOutputSystem
	{

		#region IOutputSystem Members

		public string Name
		{
			get { return "File Output System"; }
		}

		public bool IsConfigurable
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a configuration form that allows for easy output system configuration.
		/// </summary>
		/// <value></value>
		/// <returns>A configuration form that its result is fed back as arguments in GetOutput method.
		/// The form is disposed after use,therefore create a new form each time.
		/// The form must support the ShowDialog method and must return DialogResult.OK to indicate
		/// that there is new configuration data</returns>
		/// <exception cref="NotImplementedException">If this tracking system does not support configuration.</exception>
		public ConfigurationForm ConfigurationForm
		{
			get { return new FileConfigurationForm(); }
		}

		/// <summary>
		/// Gets the output object after initialization.
		/// </summary>
		/// <param name="args">The arguments that are used to initialize the Output object.Can be null to indicate no configuration.</param>
		/// <returns>A process object.</returns>
		/// <exception cref="ArgumentException">arguments value contain wrong arguments.</exception>
		public IOutput GetOutput(IDictionary<string, object> args)
		{
			return new FileOutput(args["File"].ToString());
		}

		/// <summary>
		/// Gets a description of this output system.
		/// </summary>
		/// <value>A description.</value>
		public string Description
		{
			get { return "An output system that outputs the final result into a file."; }
		}

		#endregion
	}
}