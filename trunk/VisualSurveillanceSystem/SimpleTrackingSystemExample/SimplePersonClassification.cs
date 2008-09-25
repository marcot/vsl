/*
 * Created by: efi
 * Created: Sunday, April 22, 2007
 */

using System.Collections.Generic;
using System.Drawing;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.ClassifyObjects
{
	/// <summary>
	/// Uses a very simple technique in order to classify blobs as either Person or
	/// Unknown.First it requires the the total number of pixel of the blob will be 500
	/// pixels at least and that the ration between the height of the blob and the width
	/// of the blob will be between 4 to 5 (golden ration).
	/// For information on why I chose these measurments you can read:
	/// 1. "Tracking groups of people" by McKenna.
	/// 2. http://www.goldennumbr.net/body.htm
	/// Any blob whos total size is less then 25 pixels is considered junk.
	/// </summary>
	public class SimplePersonClassification : IClassifyObjects
	{
		/// <summary>
		/// Executes classification algorithm, after running the method you will have
		/// a collection containing classified blobs.
		/// </summary>
		/// <param name="blobs">The blobs to classify.</param>
		/// <returns>
		/// A collection containing classified blobs.Collection size will be equal to blobs argument.
		/// </returns>
		public ICollection<ExtendedBlob> execute(ICollection<ExtendedBlob> blobs)
		{
			// Iterate over blobs and apply criteria.
			foreach (ExtendedBlob singleBlob in blobs)
			{
				Rectangle r = singleBlob.Rectangle;
				float ration = r.Height/r.Width;
				int size = r.Height*r.Width;
				
				if (size <= 25)
				{
					singleBlob.Class = Junk.GetInstance();
				}
				else if (size < 500) // Size criteria.
				{
					singleBlob.Class = Unknown.GetInstance();
				}
//				else if (ration > 5 && ration < 4) // Ratio criteria.
//				{
//					singleBlob.Class = ExtendedBlob.BlobClass.Unknown;
//				}
				else
				{
					singleBlob.Class = Person.GetInstance();
				}
			}

			return blobs;
		}
	}
}