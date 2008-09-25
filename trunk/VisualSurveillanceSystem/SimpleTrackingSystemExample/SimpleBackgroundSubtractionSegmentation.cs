/*
 * Created by: efi
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Zoombut.SimpleTrackingSystemExample;
using Zoombut.VisualSurveillanceLaboratory.Exceptions;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Image=System.Drawing.Image;

namespace Zoombut.VisualSurveillanceLaboratory.MotionSegmentation
{
	/// <summary>
	/// A very simple algorithm that runs Difference filter on current frame and previous
	/// frame, then uses a Threshold filter to turn it into a binary frame (a single
	/// threshold, not multiple one), then apply a connected components algorithm.
	/// </summary>
	/// <see cref="Difference"/>
	/// <see cref="Threshold"/>
	/// <see cref="BlobCounter"/>
	public class SimpleBackgroundSubtractionSegmentation : IMotionSegmentation
	{
		#region Events

		/// <summary>
		/// A delegate for hooking up changed image notifications.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void ChangedImageHandler(Object sender, ImageChangedEventArgs e);
		/// <summary>
		/// An event that clients can use to be notified whenever the
		/// image was processes and changed.
		/// </summary>
		public event ChangedImageHandler Changed;

		// Invoke the Changed event; called whenever list changes
		protected virtual void OnImageChanged(ImageChangedEventArgs e)
		{
			if (Changed != null)
				Changed(this, e);
		}

		#endregion


		#region Private variables
		/// <summary>
		/// Frame read in previous call to execute.
		/// </summary>
		private Bitmap previousFrame;
		/// <summary>
		/// Grayscale filter.
		/// </summary>
		private IFilter grayscaleFilter = new GrayscaleBT709();
		/// <summary>
		/// Difference filter.
		/// </summary>
		private Difference differenceFilter = new Difference();
		/// <summary>
		/// Threshold filter.
		/// </summary>
		private Threshold thresholdFilter = new Threshold();
		/// <summary>
		/// Erosion filter.
		/// </summary>
		private IFilter medianFilter = new Median(5);
		/// <summary>
		/// Edges filter.
		/// </summary>
		private IFilter dilitationFilter = new Dilatation();

		private Pixellate pixelateFilter = new Pixellate();
		/// <summary>
		/// Used in order to apply in place.
		/// </summary>
		private BitmapData bitmapData;
		/// <summary>
		/// Counts blobs, - connected components algorithm.
		/// </summary>
		private BlobCounter blobCounter = new BlobCounter();
		/// <summary>
		/// Width of frame.
		/// </summary>
		private int width;
		/// <summary>
		/// Height of frame.
		/// </summary>
		private int height;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleBackgroundSubtractionSegmentation"/> class.
		/// </summary>
		/// <param name="threshold">The threshold used by the Threshold filter.</param>
		public SimpleBackgroundSubtractionSegmentation(byte threshold)
		{
			thresholdFilter.ThresholdValue = threshold;
		}
		/// <summary>
		/// Execute the segmentation process.After the segmentation is over you will
		/// have a collection of moving objects that were idetified in this frame.
		/// </summary>
		/// <param name="frame">The frame.Can not be null.</param>
		/// <returns>
		/// A collection of moving objects, i.e. blobs.
		/// </returns>
		/// <exception cref="ArgumentNullException">Frame is null.</exception>
		/// <exception cref="ProcessException">Error while executing the algorithm.</exception>
		public ICollection<ExtendedBlob> execute(Bitmap frame)
		{
			/*
			 * 1. Convert image to grayscale.
			 * 2. Run Difference algorithm.
			 * 3. Use threshold of 40 to turn it into binary frame, why ? see paper
			 * "Moving target classification and tracking from real time video" by Lipton.
			 * 4. Apply connected components algorithm.
			 */

			// First time running means no prerior data to compare.
			if (previousFrame == null)
			{
				// create initial backgroung image
				previousFrame = grayscaleFilter.Apply(frame);
				// get image dimension
				width = frame.Width;
				height = frame.Height;

				// Return empty list.
				return new  List<ExtendedBlob>();
			}
			else
			{
				// apply the grayscale file
				Bitmap grayscaledImage = grayscaleFilter.Apply(frame);

				// set backgroud frame as an overlay for difference filter
				differenceFilter.OverlayImage = previousFrame;

				// apply difference filter
				Bitmap differenceImage = differenceFilter.Apply(grayscaledImage);
				
				// lock the temporary image and apply some filters on the locked data
				bitmapData = differenceImage.LockBits(new Rectangle(0, 0, width, height),
					ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

				// threshold filter
				thresholdFilter.ApplyInPlace(bitmapData);
				Bitmap medianImage = medianFilter.Apply(bitmapData);
				pixelateFilter.ApplyInPlace(medianImage);
				
				// unlock temporary image
				differenceImage.UnlockBits(bitmapData);
				differenceImage.Dispose();


				// Run connected components.
				List<ExtendedBlob> returnValue = runConectedComponentsAlgorithm(medianImage);
				// Update users.
				OnImageChanged(new ImageChangedEventArgs((Image) medianImage.Clone()));

				// Clean
				medianImage.Dispose();
				// dispose old background
				previousFrame.Dispose();
				// set backgound to current
				previousFrame = grayscaledImage;

				return returnValue;

			}

		}

		/// <summary>
		/// Merges blobs that are close to each other.
		/// </summary>
		/// <param name="value">The blobs found after running connected componenets algorithm.</param>
		/// <returns></returns>
//		private ArrayList<ExtendedBlob> mergeBlobs(ArrayList<ExtendedBlob> value)
//		{
//			/*
//			 * Using a very simple methology of merging.
//			 * Search all blobs that in close proximity of x pixels.
//			 */
//			ICollection<ExtendedBlob> intermediateValues =
//				new ArrayList<ExtendedBlob>(value.Count);
//			int x = 10;
//			ExtendedBlob closeToMe = value.RemoveAt(0);
//			while(!value.IsEmpty)
//			{
//				for (int i = 0; i < value.Count; i++)
//				{
//					Rectangle mergeRectangle = closeToMe.Rectangle;
//					mergeRectangle.Width += x;
//					mergeRectangle.Height += x;
//					if (mergeRectangle.IntersectsWith(value[i].Rectangle))
//					{
//
//						closeToMe
//						intermediateValues.Add(value[i]);
//					}
//				}
//			}
//
//		}

		/// <summary>
		/// Runs the conected components algorithm.
		/// </summary>
		/// <param name="image">The image on which to run the algorithms.</param>
		/// <returns></returns>
		private List<ExtendedBlob> runConectedComponentsAlgorithm(Bitmap image)
		{
			blobCounter = new BlobCounter(image);
			Blob[] blobs = blobCounter.GetObjects(image);
			Rectangle[] rects = blobCounter.GetObjectRectangles();
			List<ExtendedBlob> returnValue = new List<ExtendedBlob>(blobs.Length);
			for (int i = 0; i < blobs.Length; i++ )
			{
				// Use adapter method and convert blobs to extended blobs.
				returnValue.Add(new ExtendedBlob(blobs[i], null, Unknown.GetInstance(), rects[i]));
			}

			return returnValue;
		}

		public void Dispose()
		{
			if (previousFrame != null)
			{
				previousFrame.Dispose();
				previousFrame = null;
			}
		}
	}
}