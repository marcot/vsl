using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using Zoombut.VisualSurveillanceLaboratory.ImageProcess;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;

namespace Zoombut.VisualSurveillanceSystem.Controls
{
	/// <summary>
	/// Represents a view of the camera.
	/// </summary>
	public class Camera
	{
		/// <summary>
		/// Read video data from this source.
		/// </summary>
		private readonly IVideoSource videoSource = null;
		/// <summary>
		/// The entire image process system.
		/// </summary>
		private readonly IImageProcess imageProcess;
		/// <summary>
		/// Last frame read.
		/// </summary>
		private Bitmap lastFrame = null;
		/// <summary>
		/// Where to ouput results.s
		/// </summary>
		private readonly IOutput output;
		/// <summary>
		/// Change image before displaying it on screen.
		/// </summary>
		private readonly GraphicalOutputDelegate graphicalOutput;

		private readonly PictureBox pictureBox;

		/// <summary>
		/// Stop video feed.
		/// </summary>
		public void Stop()
		{
			if (videoSource != null)
			{
				videoSource.Stop();
			}
		}
		/// <summary>
		/// Start video feed.
		/// </summary>
		public void Start()
		{
			if (videoSource != null)
			{
				videoSource.Start();
			}
		}

		/// <summary>
		/// Signal video source to stop.
		/// </summary>
		public void SignalToStop()
		{
			if (videoSource != null)
			{
				videoSource.SignalToStop();
			}
		}

		/// <summary>
		/// Wait video source for stop
		/// </summary>
		public void WaitForStop()
		{
			// lock
			Monitor.Enter(this);

			if (videoSource != null)
			{
				videoSource.WaitForStop();
			}
			// unlock
			Monitor.Exit(this);
		}

		/// <summary>
		/// Create new Camera object.
		/// </summary>
		/// <param name="source">Video source.</param>
		/// <param name="imageProcess">The image process system.</param>
		/// <param name="output">To where output results.</param>
		/// <param name="graphicalOutput">How to change the graphical output.</param>
		/// <param name="pictureBox">Where to display the final image.</param>
		public Camera(IVideoSource source, IImageProcess imageProcess, IOutput output, 
			GraphicalOutputDelegate graphicalOutput, PictureBox pictureBox)
		{
			if (source == null) throw new ArgumentNullException("source");
			if (imageProcess == null) throw new ArgumentNullException("imageProcess");
			if (output == null) throw new ArgumentNullException("output");
			if (graphicalOutput == null) throw new ArgumentNullException("graphicalOutput");
			if (pictureBox == null) throw new ArgumentNullException("pictureBox");

			videoSource = source;
			videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
			this.imageProcess = imageProcess;
			this.output = output;
			this.graphicalOutput = graphicalOutput;
			this.pictureBox = pictureBox;
		
		}

		private void video_NewFrame(object sender, NewFrameEventArgs e)
		{
			// dispose old frame
			//if (lastFrame != null)
			//{
			//	lastFrame.Dispose();
			//}

			lastFrame = (Bitmap)e.Frame.Clone();
			
			// apply motion detector
			if (imageProcess != null)
			{
				ICollection<ExtendedBlob> results = imageProcess.ProcessFrame(lastFrame);
				output.Output(results);
				graphicalOutput(results, lastFrame);
				// Update picture box.
				pictureBox.Image = lastFrame;
				//pictureBox.Invoke(new UpdateImageCallback(updateImage), lastFrame);

			}
		}

		public delegate void UpdateImageCallback(Bitmap bitmap);
		private void updateImage(Bitmap bitmap)
		{
			pictureBox.Image = bitmap;
		}
	}
}