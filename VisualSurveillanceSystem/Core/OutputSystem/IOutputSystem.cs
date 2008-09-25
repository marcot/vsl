/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 29, 2007
 */

using System;
using System.Collections.Generic;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;

namespace Zoombut.VisualSurveillanceLaboratory.OutputSystem
{
	public interface IOutputSystem
	{
		/// <summary>
		/// Gets the name of the output system.
		/// </summary>
		/// <value>The name.</value>
		String Name
		{
			get;
		}
		/// <summary>
		/// If this out system is configurable then the configuration ability
		/// at the Visual Surveillance Workshop will be enabled.
		/// You should also implement GetConfigurationForm method if this method returns
		/// true.
		/// </summary>
		/// <returns>True if output system is configurable, false otherwise.</returns>
		bool IsConfigurable
		{
			get;
		}
		/// <summary>
		/// Gets a configuration form that allows for easy output system configuration.
		/// </summary>
		/// <returns>A configuration form that its result is fed back as args in GetOutput method.
		/// The form is disposed after use,therefore create a new form each time.
		/// The form must support the ShowDialog method and must return DialogResult.OK to indicate
		/// that there is new configuration data</returns>
		/// <exception cref="NotImplementedException">If this tracking system does not support configuration.</exception>
		ConfigurationForm ConfigurationForm
		{
			get;
		}

		/// <summary>
		/// Gets the output object after initialization.
		/// </summary>
		/// <param name="args">The args that are used to initialize the Output object.Can be null to indicate no configuration.</param>
		/// <returns>A process object.</returns>
		/// <exception cref="ArgumentException">args value contain wrong arguments.</exception>
		IOutput GetOutput(IDictionary<String, Object> args);

		/// <summary>
		/// Gets a description of this output system.
		/// </summary>
		/// <value>A description.</value>
		String Description
		{ get;
		}
	}
}