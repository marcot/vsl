/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Saturday, April 28, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zoombut.VisualSurveillanceLaboratory.ImageProcess;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem
{
	/// <summary>
	/// A mehtod which changes the image to be dispalyed on main gui accroding to the blobs
	/// found after the tracking algorithm has finished runnung.
	/// </summary>
	/// <param name="blobs">Blobs that were found after tracking algorithm ran.</param>
	/// <param name="image">Image that will be displayed on screen.</param>
	public delegate void GraphicalOutputDelegate(ICollection<ExtendedBlob> blobs, Image image);
	/// <summary>
	/// Encapsulates an entire tracking system which includes configuration possiilities,
	/// run time configuration and online debug info.
	/// </summary>
	public interface ISurveillanceSystem
	{
		/// <summary>
		/// Gets the name of the tracking system.
		/// </summary>
		/// <value>The name.</value>
		String Name
		{ get;
		}
		/// <summary>
		/// If this tracking system is configurable then the configuration ability
		/// at the Visual Surveillance Workshop will be enabled.
		/// You should also implement GetConfigurationForm method if this method returns
		/// true.
		/// </summary>
		/// <returns>True if tracking system is configurable, false otherwise.</returns>
		bool IsConfigurable
		{ get;
		}
		/// <summary>
		/// Gets a configuration form that allows for easy tracking system configuration.
		/// </summary>
		/// <returns>A configuration form that its result is fed back as args in GetImageProcess method.
		/// The form is disposed after use,therefore create a new form each time.
		/// The form must support the ShowDialog method and must return DialogResult.OK to indicate
		/// that there is new configuration data</returns>
		/// <exception cref="NotImplementedException">If this tracking system does not support configuration.</exception>
		ConfigurationForm ConfigurationForm
		{ get;
		}
		/// <summary>
		/// Gets the image process object after initialization.
		/// </summary>
		/// <param name="args">The args that are used to initialize the ImageProcess object.Can be null to indicate no configuration.</param>
		/// <returns>A process object.</returns>
		/// <exception cref="ArgumentException">args value contain wrong arguments.</exception>
		IImageProcess GetImageProcess(IDictionary<String, Object> args);
		/// <summary>
		/// Determines whether this tracking system can be configured in runtime.
		/// Usually runtime configuration should take into considiration threading
		/// issues.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if is runtime configurable; otherwise, <c>false</c>.
		/// </returns>
		bool IsRuntimeConfigurable
		{ get;
		}
		/// <summary>
		/// Gets a runtime configuration form.
		/// </summary>
		/// <returns>A configuration form that its result is fed back as args in SetRuntimeConfiguration method.</returns>
		ConfigurationForm RuntimeConfigurationForm
		{ get;
		}
		/// <summary>
		/// Sets runtime configuration for the tracking system.
		/// Make sure that this method supports threading.
		/// </summary>
		/// <param name="args">The args that contain configuration data.</param>
		/// <exception cref="NotImplementedException">If this tracking system does not support runtime configuration.</exception>
		void SetRuntimeConfiguration(IDictionary<String, Object> args);
		/// <summary>
		/// Gets a description of this tracking system.
		/// </summary>
		/// <value>A description.</value>
		String Description
		{ get;
		}
		/// <summary>
		/// Determines whether this tracking system supports runtime information that
		/// can be displayed for the user.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if has runtime information; otherwise, <c>false</c>.
		/// </returns>
		bool HasRuntimeInformation
		{ get;
		}
		/// <summary>
		/// Gets a form that displayes runtime information.The form is displayed for
		/// the user.
		/// </summary>
		/// <returns>A form that displayes runtime information.</returns>
		Form RuntimeInformation
		{ get;
		}

		/// <summary>
		/// Closes this resoureces used by this tracking system.
		/// </summary>
		void Close();

		bool HasGraphicalOutput
		{ get;
		}

		GraphicalOutputDelegate GraphicalOutput
		{ get;
		}
	}
}