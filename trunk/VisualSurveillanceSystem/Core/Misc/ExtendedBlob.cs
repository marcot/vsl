/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 22, 2007
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using AForge.Imaging;

namespace Zoombut.VisualSurveillanceLaboratory.Misc
{

	#region Helper blob classes

	public class Person : ExtendedBlob.BlobClass
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Person instance = new Person();

		/// <summary>
		/// Singleton constructor.
		/// </summary>
		private Person()
		{
			//TODO
		}

		/// <summary>
		/// Get singleton instance.
		/// </summary>
		public static Person GetInstance()
		{
			return instance;
		}

		#region BlobClass Members

		/// <summary>
		/// Name of class.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return "Person"; }
		}

		#endregion
	}

	public class Junk : ExtendedBlob.BlobClass
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Junk instance = new Junk();

		/// <summary>
		/// Singleton constructor.
		/// </summary>
		private Junk()
		{
			//TODO
		}

		/// <summary>
		/// Get singleton instance.
		/// </summary>
		public static Junk GetInstance()
		{
			return instance;
		}

		#region BlobClass Members

		/// <summary>
		/// Name of class.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return "Junk"; }
		}

		#endregion
	}
	public class Unknown : ExtendedBlob.BlobClass
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Unknown instance = new Unknown();

		/// <summary>
		/// Singleton constructor.
		/// </summary>
		private Unknown()
		{
			//TODO
		}

		/// <summary>
		/// Get singleton instance.
		/// </summary>
		public static Unknown GetInstance()
		{
			return instance;
		}

		#region BlobClass Members

		/// <summary>
		/// Name of class.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return "Unknown"; }
		}

		#endregion
	}

	#endregion


	/// <summary>
	/// Adds several features to the basic blob class.
	/// </summary>
	public class ExtendedBlob : Blob
	{
		#region Private variables
		/// <summary>
		/// Adds several features to the blob class.
		/// </summary>
		private String id;
		/// <summary>
		/// To which classes a blob belongs to.
		/// </summary>
		private BlobClass blobClass;
		/// <summary>
		/// A rectangle that surrounds the blob.
		/// </summary>
		private Rectangle blobRectangle;
		#endregion

		/// <summary>
		/// To which classes a blob belongs to.
		/// </summary>
		public interface BlobClass
		{
			/// <summary>
			/// Name of class.
			/// </summary>
			/// <value>The name.</value>
			String Name
			{ get;
			}
		}

		#region Constructors

		private void initialize(String blobId, BlobClass bClass, Rectangle rectangle)
		{
			id = blobId;
			blobClass = bClass;
			blobRectangle = rectangle;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedBlob"/> class.
		/// </summary>
		/// <param name="image">The image.</param>
		/// <param name="location">The location.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="id">The id of the blob.Null indicates unknown id.</param>
		/// <param name="blobClass">To which classes a blob belongs to.</param>
		/// <param name="rectangle">The rectangle that surounds the blob.Can not be null.</param>
		/// <see cref="Blob"/>
		/// <exception cref="ArgumentNullException">Any of the arguments is null.</exception>
		public ExtendedBlob(Bitmap image, Point location, Bitmap owner, string id, BlobClass blobClass, Rectangle rectangle)
			: base(1, rectangle, owner)
		{
			initialize(id, blobClass, rectangle);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedBlob"/> class.
		/// An adapter from a regular blob class.
		/// </summary>
		/// <param name="blob">The blob.</param>
		/// <param name="id">The id of the blob.Null indicates unknown id.</param>
		/// <param name="blobClass">To which classes a blob belongs to.</param>
		/// <param name="rectangle">The rectangle that surounds the blob.Can not be null.</param>
		/// <see cref="Blob"/>
		/// <exception cref="ArgumentNullException">Any of the arguments is null.</exception>
		public ExtendedBlob(Blob blob, String id, BlobClass blobClass, Rectangle rectangle)
			: base(1, rectangle, blob.Image)
		{
			
			initialize(id, blobClass, rectangle);
		} 
		#endregion

		public override string ToString()
		{
			// Make sure you are not printing null.
			String finalId = id == null ? "Unknown" : id;
			return string.Format("ID: {0} Class: {1} Location: {2}", finalId, blobClass.Name, Rectangle);
		}


		/// <summary>
		/// Gets or sets the blob id.
		/// </summary>
		/// <value>The id.</value>
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// Gets the blob class.
		/// </summary>
		/// <value>The class.</value>
		public BlobClass Class
		{
			get { return blobClass; }
			set { blobClass = value;}
		}


		/// <summary>
		/// Gets the blob rectangle.
		/// </summary>
		/// <value>The blob rectangle.</value>
		public Rectangle Rectangle
		{
			get { return blobRectangle; }
		}

		/// <summary>
		/// Checks for position equality of the blob, position equality is
		/// determined by the blob surounding rectangle.
		/// </summary>
		/// <param name="eb">The eb.</param>
		/// <returns></returns>
		public bool PositionEquality(ExtendedBlob eb)
		{
			return (eb.Rectangle.Equals(Rectangle));
		}

		public class PositionEqulityComparator : IEqualityComparer<ExtendedBlob>
		{
			#region IEqualityComparer<ExtendedBlob> Members

			///<summary>
			///Determines whether the specified objects are equal.
			///</summary>
			///
			///<returns>
			///true if the specified objects are equal; otherwise, false.
			///</returns>
			///
			///<param name="y">The second object of type T to compare.</param>
			///<param name="x">The first object of type T to compare.</param>
			public bool Equals(ExtendedBlob x, ExtendedBlob y)
			{
				return x.PositionEquality(y);
			}

			///<summary>
			///Returns a hash code for the specified object.
			///</summary>
			///
			///<returns>
			///A hash code for the specified object.
			///</returns>
			///
			///<param name="obj">The <see cref="T:System.Object"></see> for which a hash code is to be returned.</param>
			///<exception cref="T:System.ArgumentNullException">The type of obj is a reference type and obj is null.</exception>
			public int GetHashCode(ExtendedBlob obj)
			{
				return obj.Rectangle.GetHashCode();
			}

			#endregion
		}
	}
}