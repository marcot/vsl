/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using Zoombut.Utils.Misc;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.TrackObjects
{
	/// <summary>
	/// Implements a very simple tracking algorithm.
	/// </summary>
	public class SimpleTrackingAlgorithm : ITrackObjects
	{
		#region Private variables
		/// <summary>
		/// Blobs that are not considered yet to be a real object.
		/// The dictionary contains a special id as key and 
		/// number of times this blob appeared and the blob itself is value.
		/// </summary>
		private IDictionary<string, RPair<ExtendedBlob, int>> pendingBlobs = new Dictionary<string, RPair<ExtendedBlob, int>>();

		/// <summary>
		/// Blobs that are considered to be a real object.
		/// The dictionary contains special id as key and the number of frames the active blob was not updated and the blob
		/// itself as value.
		/// </summary>
		private IDictionary<string, RPair<ExtendedBlob, int>> activeBlobs = new Dictionary<string, RPair<ExtendedBlob, int>>();
		/// <summary>
		/// Nxt id number to give.
		/// </summary>
		private int nextId = 1; 
		#endregion

		/// <summary>
		/// Executes a tracking algorithm.After executing you will have a collection of
		/// identifyable blobs, i.e. with id.
		/// </summary>
		/// <param name="blobs">The blobs to track.Does not have to make a defensive copy.</param>
		/// <returns>
		/// A collection containing identifyable blobs, size of return value does not have to match the size of blobs argument.
		/// </returns>
		public ICollection<ExtendedBlob> execute(ICollection<ExtendedBlob> blobs)
		{
			/*
			 *Algorithm:
			 * Iterate over all blobs, ignoring Unknown blobs.
			 *		if pendingBlobs contains blob then 
			 *			increase the size of pending blob by 1.
			 *			update blob location.
			 *			if pending blob frame time >= 4 then move blob to activeBlobs and give them id.
			 *		else if activeBlobs contains blob
			 *			update blob location.
			 *			initialize times not touched to 0.
			 *		else
			 *			add blob to pending blobs.
			 * 
			 * Iterate over all pending blobs
			 *		delete blob if it wasn't updated.
			 *	
			 * Iterate over all active blobs
			 *		delete blob if it wasn't updated for 10 frames.
			 * return blobs in activeBlobs list.
			 */

			// Contains blobs that were updated in pending list.
			IDictionary<String, Object> pendingUpdated = new Dictionary<String, Object>();
			// Contains blobs that were updated in active list.
			IDictionary<String, Object> activeUpdated = new Dictionary<String, Object>();
			foreach (ExtendedBlob blob in blobs)
			{
				if (blob.Class == Person.GetInstance())
				{
					// If returns a real location it means it found something.
					String location = containBlob(blob, pendingBlobs);
					if (location != null)
					{
						RPair<ExtendedBlob, int> pendinBlob = pendingBlobs[location];
						if (!pendingUpdated.ContainsKey(location))
						{
							pendingUpdated.Add(location, null);
						}
						// Update number of times seen.
						pendinBlob.Second = pendinBlob.Second + 1;
						// Update location.
						pendinBlob.First = blob;
						// if pending blob frame time = 4 then move blob to activeBlobs.
						if (pendinBlob.Second == 4)
						{
							pendingBlobs.Remove(location);
							// Initialize the number of times it was not seen.
							pendinBlob.Second = 0;
							// Set id.
							pendinBlob.First.Id = location;
							activeBlobs.Add(pendinBlob.First.Id, pendinBlob);
						}
					}
					else
					{
						location = containBlob(blob, activeBlobs);
						//  if activeBlobs contains blob
						if (location != null)
						{
							// Indicate that this blob was updated.
							if (!activeUpdated.ContainsKey(location))
							{
								activeUpdated.Add(location, null);
							}
							RPair<ExtendedBlob, int> activeBlob = activeBlobs[location];
							String id = activeBlob.First.Id;
							// update blob location.
							activeBlob.First = blob;
							// blob does not contain any id.
							activeBlob.First.Id = id;

							// initialize time not touched.
							activeBlob.Second = 0;
						}
						else // Add to pending blobs.
						{
							String id = nextId.ToString();
							pendingBlobs.Add(id, new RPair<ExtendedBlob, int>(blob, 1));
							// Just added it.
							pendingUpdated.Add(id, null);
							nextId++;
						}
					}
				}

				
			}
			// Delete values from pending lists that weren't updated this frame.
			deleteFromPending(pendingUpdated);

			deleteFromActive(activeUpdated);


			return getBlobs(activeBlobs);
		}

		#region Helper methods

		/// <summary>
		/// Deletes from active.
		/// </summary>
		/// <param name="activeUpdated">The active updated.</param>
		private void deleteFromActive(IDictionary<string, object> activeUpdated)
		{
			// Clean all pending values that weren't touced this frame.
			ICollection<String> deleteList = new LinkedList<String>();
			foreach (KeyValuePair<string, RPair<ExtendedBlob, int>> blob in activeBlobs)
			{
				if (!activeUpdated.ContainsKey(blob.Key)) // Means it was not updated.
				{
					RPair<ExtendedBlob, int> extBlob = blob.Value;
					extBlob.Second += 1;
					if (extBlob.Second > 10)
					{
						deleteList.Add(blob.Key);
					}
				}
			}

			deleteFromDictionary(deleteList, activeBlobs);
		}

		/// <summary>
		/// Deletes from pending list.
		/// </summary>
		/// <param name="pendingUpdated">The pending updated values.</param>
		private void deleteFromPending(IDictionary<string, object> pendingUpdated)
		{
			// Clean all pending values that weren't touced this frame.
			ICollection<String> deleteList = new LinkedList<String>();
			foreach (KeyValuePair<string, RPair<ExtendedBlob, int>> blob in pendingBlobs)
			{
				if (!pendingUpdated.ContainsKey(blob.Key)) // Means it was not updated.
				{
					deleteList.Add(blob.Key);
				}
			}

			deleteFromDictionary(deleteList, pendingBlobs);
		}

		/// <summary>
		/// Deletes from a dictionary.
		/// </summary>
		/// <param name="deleteList">The delete list.</param>
		/// <param name="dictionary">The dictionary.</param>
		private static void deleteFromDictionary(ICollection<string> deleteList, IDictionary<string, RPair<ExtendedBlob, int>> dictionary)
		{
			// Actually delete.
			foreach (string s in deleteList)
			{
				RPair<ExtendedBlob, int> blob = dictionary[s];
				dictionary.Remove(s);
			}
		}

		/// <summary>
		/// Gets the blobs.
		/// </summary>
		/// <param name="blobs">The blobs.</param>
		private static ICollection<ExtendedBlob> getBlobs(ICollection<KeyValuePair<string, RPair<ExtendedBlob, int>>> blobs)
		{
			ICollection<ExtendedBlob> returnValue = new List<ExtendedBlob>(blobs.Count);

			foreach (KeyValuePair<String, RPair<ExtendedBlob, int>> singleBlob in blobs)
			{
				returnValue.Add(singleBlob.Value.First);
			}

			return returnValue;
		}

		/// <summary>
		/// Checks if list contains a certain blob.It does it by checking if the
		/// rectangle surounding the blob intersects with other blobs in list.
		/// The algorithm returns the position of the one with the biggest intersection.
		/// </summary>
		/// <param name="blob">The blob  to search for,.</param>
		/// <param name="blobsList">The blobs list.</param>
		/// <returns>Blob id that was found in the collection that intersects with the given argument.null if none was found.</returns>
		private static String containBlob(ExtendedBlob blob, ICollection<KeyValuePair<String, RPair<ExtendedBlob, int>>> blobsList)
		{
			Rectangle blobRetangle = blob.Rectangle;
			int maxIntersectSize = 0;
			String returnValue = null;
			// Man...this is ugly
			foreach (KeyValuePair<String, RPair<ExtendedBlob, int>> value in blobsList)
			{
				// Intersect both rectangles.
				RPair<ExtendedBlob, int> exBlob = value.Value;
				Rectangle intersect = Rectangle.Intersect(exBlob.First.Rectangle, blobRetangle);
				// Check size of intersected rectangle if it's bigger then max.
				int size = intersect.Width * intersect.Height;
				if (size > maxIntersectSize)
				{
					returnValue = value.Key; // Update location.
					maxIntersectSize = size;
				}
			}

			return returnValue ;
		} 
		#endregion
	}
}