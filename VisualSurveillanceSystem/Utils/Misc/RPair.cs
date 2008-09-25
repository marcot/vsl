namespace Zoombut.Utils.Misc
{
	/// <summary>
	/// Represents a pair of objects with different types.
	/// R stand for reference, this is not a struct.
	/// </summary>
	/// <typeparam name="F">First value.</typeparam>
	/// <typeparam name="S">Second value.</typeparam>
	public class RPair<F, S>
	{
		#region public variables
		/// <summary>
		/// First value.
		/// </summary>
		public   F First;
		/// <summary>
		/// Second value.
		/// </summary>
		public S Second; 
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="RPair{F,S}"/> class.
		/// </summary>
		/// <param name="first">The first value.</param>
		/// <param name="second">The second value.</param>
		public RPair(F first, S second)
		{
			First = first;
			Second = second;
		}
	}
}
