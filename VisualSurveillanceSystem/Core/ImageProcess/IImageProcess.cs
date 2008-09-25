/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using Zoombut.VisualSurveillanceLaboratory.Exceptions;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.ImageProcess
{
	/// <summary>
	/// Represents an image process builder.
	/// This builder is responsiable for running various algorithms in order to track
	/// moving objects in a stream of video.
	/// </summary>
	public interface IImageProcess
	{
		/// <summary>
		/// Processes a single frame according to the algorithms given to the builder.
		/// </summary>
		/// <param name="frame">A frame.Can not be null.</param>
		/// <returns>A collection containing id's of objects and their current position in frame.</returns>
		/// <exception cref="ArgumentNullException">Frame is null.</exception>
		/// <exception cref="ProcessException">Error in the process sequence.</exception>
		ICollection<ExtendedBlob> ProcessFrame(Bitmap frame);
	}
}