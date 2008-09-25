/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using Zoombut.VisualSurveillanceLaboratory.ClassifyObjects;
using Zoombut.VisualSurveillanceLaboratory.Exceptions;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Zoombut.VisualSurveillanceLaboratory.TrackObjects;

namespace Zoombut.VisualSurveillanceLaboratory.MotionSegmentation
{
	/// <summary>
	/// Encapsulates the segmentation process.
	/// The segmentation process finds moving objects, however it does not decide if the
	/// moving objects are important for tracking or not.
	/// <see cref="IClassifyObjects"/>
	/// <see cref="ITrackObjects"/>
	/// </summary>
	public interface IMotionSegmentation : IDisposable
	{
		/// <summary>
		/// Execute the segmentation process.After the segmentation is over you will
		/// have a collection of moving objects that were idetified in this frame.
		/// </summary>
		/// <param name="frame">The frame.Can not be null.</param>
		/// <returns>A collection of moving objects, i.e. blobs.</returns>
		/// <exception cref="ArgumentNullException">Frame is null.</exception>
		/// <exception cref="ProcessException">Error while executing the algorithm.</exception>
		ICollection<ExtendedBlob> execute(Bitmap frame);
	}
}