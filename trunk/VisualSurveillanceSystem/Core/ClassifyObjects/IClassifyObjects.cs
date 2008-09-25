/*
 * Created by: Efi
 * Created: Sunday, April 22, 2007
 */


using System.Collections.Generic;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.ClassifyObjects
{
	/// <summary>
	/// Classifies blobs.Usually this process happens after motion segmentation, however
	/// it does not have to be so.There are many classification types, it all depends on
	/// how much you want your algorithm to be more thoroughly.
	/// <see cref="ExtendedBlob.BlobClass"/>
	/// </summary>
	public interface IClassifyObjects
	{
		/// <summary>
		/// Executes classification algorithm, after running the method you will have
		/// a collection containing classified blobs.
		/// </summary>
		/// <param name="blobs">The blobs to classify.Does not have to make a defensive copy.</param>
		/// <returns>A collection containing classified blobs.Collection size will be equal to blobs argument.</returns>
		ICollection<ExtendedBlob> execute(ICollection<ExtendedBlob> blobs);
	}
}