/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System.Collections.Generic;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.TrackObjects
{
	/// <summary>
	/// Tracking objects gives me the ability to identify blobs (by a special id), by 
	/// doing that I'm able to give each identifyable blob a location which allows me
	/// to do further processing.
	/// </summary>
	public interface ITrackObjects
	{
		/// <summary>
		/// Executes a tracking algorithm.After executing you will have a collection of
		/// identifyable blobs, i.e. with id.
		/// </summary>
		/// <param name="blobs">The blobs to track.Does not have to make a defensive copy.</param>
		/// <returns>A collection containing identifyable blobs, size of return value does not have to match the size of blobs argument.</returns>
		ICollection<ExtendedBlob> execute(ICollection<ExtendedBlob> blobs);
	}
}