using System;
using System.Collections.Generic;
using System.IO;
using Zoombut.VisualSurveillanceLaboratory.Misc;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;

namespace Zoombut.FileOutputSystem
{
	public class FileOutput : IOutput
	{
		private TextWriter writer;
		
		private Int32 time = 1;
		/// <summary>
		/// Initializes a new instance of the <see cref="FileOutput"/> class.
		/// </summary>
		/// <param name="path">A path at which to write the file.Can not be null.If path already exists file will be opened.</param>
		public FileOutput(String path)
		{
			writer =
				new StreamWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.Write));

		}

		#region IOutput Members

		/// <summary>
		/// Outputs the specified blobs.
		/// </summary>
		/// <param name="blobs">The blobs to output.</param>
		/// <exception cref="IOException">Error while trying to output the blobs.</exception>
		/// <exception cref="ObjectDisposedException">Output object is already closed.</exception>
		public void Output(ICollection<ExtendedBlob> blobs)
		{
			foreach (ExtendedBlob blob in blobs)
			{
				writer.WriteLine("{0},{1},{2},{3}", blob.Id, blob.Rectangle.X, blob.Rectangle.Y, time);
				time++;
			}
			writer.Flush();
		}
		/// <summary>
		/// Closes the output.
		/// </summary>
		/// /// 
		/// <exception cref="IOException">Error while trying to close.</exception>
		public void Close()
		{
			writer.Close();
		}

		#endregion
	}
}
