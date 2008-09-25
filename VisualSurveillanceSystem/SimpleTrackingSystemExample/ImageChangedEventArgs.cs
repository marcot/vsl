/*
 * Created by: efi merdlee@kdictionaries.com
 * Created: Saturday, April 28, 2007
 */
using System;
using System.Drawing;

namespace Zoombut.SimpleTrackingSystemExample
{
	public class ImageChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Holds the changed image.
		/// </summary>
		private Image image;

		/// <summary>
		/// Initializes a new instance of the <see cref="ImageChangedEventArgs"/> class.
		/// </summary>
		/// <param name="image">The image that was changed.</param>
		public ImageChangedEventArgs(Image image)
		{
			this.image = image;
		}

		public Image Image
		{
			get { return image; }
		}
	}
}