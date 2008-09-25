/*
 * Created by: Efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using Zoombut.VisualSurveillanceLaboratory.ClassifyObjects;
using Zoombut.VisualSurveillanceLaboratory.Exceptions;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Zoombut.VisualSurveillanceLaboratory.MotionSegmentation;
using Zoombut.VisualSurveillanceLaboratory.TrackObjects;

namespace Zoombut.VisualSurveillanceLaboratory.ImageProcess
{
	/// <summary>
	/// A default image process class that is using various process techniques.
	/// </summary>
	public class BaseImageProcess : IImageProcess
	{

		#region private variables.

		protected IMotionSegmentation motionSegmentation;
		protected IClassifyObjects classifyObjects;
		protected ITrackObjects trackObjects;
		#endregion

		/// <summary>
		/// A constructor
		/// </summary>
		/// <param name="ms">The Background Subtraction algorithm.</param>
		/// <param name="classObj">The Classify Blobs algorithm.</param>
		/// <param name="tracker">The Tracking algorithm.</param>
		/// <exception cref="ArgumentNullException">One of the arguments is null.</exception>
		public BaseImageProcess(IMotionSegmentation ms, IClassifyObjects classObj, ITrackObjects tracker)
		{
			// Check that non is null.
			if (ms == null || tracker == null || classObj == null)
			{
				throw new ArgumentNullException();
			}

			motionSegmentation = ms;
			trackObjects = tracker;
			classifyObjects = classObj;
		}

		/// <summary>
		/// Processes a single frame according to the algorithms given to the builder.
		/// </summary>
		/// <param name="frame">A frame.Can not be null.Does not make defensive copy of variable.</param>
		/// <returns>
		/// A collection containing id's of objects and their current position in frame.
		/// </returns>
		/// <exception cref="ArgumentNullException">Frame is null.</exception>
		/// <exception cref="ProcessException">Error in the process sequence.</exception>
		public ICollection<ExtendedBlob> ProcessFrame(Bitmap frame)
		{
			// Find regions of moving objects.
			ICollection<ExtendedBlob> blobs = motionSegmentation.execute(frame);
			// Classify blobs.
			ICollection<ExtendedBlob> classifiedBlobs = classifyObjects.execute(blobs);
			// Track blobs.
			ICollection<ExtendedBlob> finalLocation =
				trackObjects.execute(classifiedBlobs);

			return finalLocation;
		}
	}
}