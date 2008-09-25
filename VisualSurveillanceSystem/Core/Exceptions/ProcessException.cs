/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;

namespace Zoombut.VisualSurveillanceLaboratory.Exceptions
{
	/// <summary>
	/// Usually a base exception for various exceptions that occur during the image
	/// process.
	/// </summary>
	public class ProcessException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessException"/> class.
		/// </summary>
		public ProcessException()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public ProcessException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public ProcessException(string message) : base(message)
		{
		}
	}
}