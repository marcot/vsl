/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 29, 2007
 */

using System;
using System.Collections.Generic;
using System.IO;
using Zoombut.VisualSurveillanceLaboratory.Misc;

namespace Zoombut.VisualSurveillanceLaboratory.OutputSystem
{
	/// <summary>
	/// Output Tracked objects.Output can be into a a stream, a database etc...
	/// </summary>
	public interface IOutput
	{
		/// <summary>
		/// Outputs the specified blobs.
		/// </summary>
		/// <param name="blobs">The blobs to output.</param>
		/// <exception cref="IOException">Error while trying to output the blobs.</exception>
		/// <exception cref="ObjectDisposedException">Output object is already closed.</exception>
		void Output(ICollection<ExtendedBlob> blobs);

		/// <summary>
		/// Closes the output.
		/// </summary>
		/// /// <exception cref="IOException">Error while trying to close.</exception>
		void Close();
	}
}