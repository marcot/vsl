/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Saturday, April 28, 2007
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zoombut.VisualSurveillanceLaboratory.ClassifyObjects;
using Zoombut.VisualSurveillanceLaboratory.ImageProcess;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Zoombut.VisualSurveillanceLaboratory.MotionSegmentation;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;
using Zoombut.VisualSurveillanceLaboratory.TrackObjects;

namespace Zoombut.SimpleTrackingSystemExample
{
	/// <summary>
	/// Shows an example of a tracking system using all configuration possibilities.
	/// </summary>
	public class ExampleTrackingSystem : ISurveillanceSystem
	{
		/// <summary>
		/// Holds the moton segmentation algorithm.
		/// </summary>
		private SimpleBackgroundSubtractionSegmentation segementation;

		// Draw rectangles around blob.
		private static Font font = new Font("Ariel", 10);
		private static Pen pen = new Pen(Color.Red, 1);
		private static Brush brush = new SolidBrush(Color.Red);

		#region ISurveillanceSystem Members

		public string Name
		{
			get { return "Example Tracking System"; }
		}

		public bool IsConfigurable
		{
			get
			{
				return true;
			}
		}

		public ConfigurationForm ConfigurationForm
		{
			get
			{
				// I do not want to take a chance that someone will Dispose my form.
				// Therefore I'm not creating it on global leve.
				ConfigurationForm configForm = new ExampleConfigurationForm();
				return configForm;
			}
		}

		/// <summary>
		/// Gets the image process object after initialization.
		/// </summary>
		/// <param name="args">The args that are used to initialize the ImageProcess object. Can not be null.</param>
		/// <returns>A process object.</returns>
		/// <exception cref="ArgumentException">Args should contain Threshold key with value of type byte.</exception>
		public IImageProcess GetImageProcess(IDictionary<string, object> args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args can not be null.");
			}
			// Get arguments.
			byte threshold;
			try
			{
				threshold = (byte)args["Threshold"];
			}
			catch (Exception) // Either key does not exist or not a byte type.
			{
				throw new ArgumentException(
					"Args should contain Threshold key with value of type byte");
			}
			segementation = new SimpleBackgroundSubtractionSegmentation(threshold);
			return
					new BaseImageProcess(
						segementation,
						new SimplePersonClassification(),
						new SimpleTrackingAlgorithm());
		}

		/// <summary>
		/// Determines whether this tracking system can be configured in runtime.
		/// Usually runtime configuration should take into considiration threading
		/// issues.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// 	<c>true</c> if is runtime configurable; otherwise, <c>false</c>.
		/// </returns>
		public bool IsRuntimeConfigurable
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a runtime configuration form.
		/// </summary>
		/// <value></value>
		/// <returns>A configuration form that its result is fed back as args in SetRuntimeConfiguration method.</returns>
		public ConfigurationForm RuntimeConfigurationForm
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void SetRuntimeConfiguration(IDictionary<string, object> args)
		{
			throw new NotImplementedException();
		}

		public string Description
		{
			get { return "A simple tracking system used to show how to build one.\n" +
				"For information on the various parts please see the documentation.\n" +
				"Created by Merdler Efi - efi.merdler@gmail.com"; }
		}

		public bool HasRuntimeInformation
		{
			get { return true; }
		}

		public Form RuntimeInformation
		{
			get
			{
				ExampleRuntimeInformationForm returnValue =
					new ExampleRuntimeInformationForm();
				// Hook events.
				segementation.Changed +=
					new SimpleBackgroundSubtractionSegmentation.ChangedImageHandler(
						returnValue.ImageChanged);
				return returnValue;
			}
		}

		/// <summary>
		/// Closes this resoureces used by this tracking system.
		/// </summary>
		public void Close()
		{
			// Do nothing.
		}

		public bool HasGraphicalOutput
		{
			get { return true; }
		}

		public GraphicalOutputDelegate GraphicalOutput
		{
			get { return new GraphicalOutputDelegate(drawRectanglesOnBlobs); }
		}

		#endregion

		/// <summary>
		/// Draws rectangle on an image.
		/// </summary>
		/// <param name="blobs">The blobs.</param>
		/// <param name="image">The image on which to draw.</param>
		private static void drawRectanglesOnBlobs(ICollection<ExtendedBlob> blobs, Image image)
		{
			// create graphics object from initial image
			Graphics g = Graphics.FromImage(image);
			foreach (ExtendedBlob blob in blobs)
			{
				g.DrawRectangle(pen, blob.Rectangle);
				g.DrawString(blob.Id, font, brush, blob.Rectangle);
			}
			g.Dispose();
		}
	}
}