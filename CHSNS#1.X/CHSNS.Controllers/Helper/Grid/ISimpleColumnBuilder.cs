namespace CHSNS.Helper{
	using System;

	/// <summary>
	/// Used in the construction of Grid columns. 
	/// </summary>
	/// <typeparam name="T">Type of item to render the column for.</typeparam>
	public interface ISimpleColumnBuilder<T> : INestedGridColumnBuilder<T> where T : class
	{
		/// <summary>
		/// Specifies a custom delegate for the rendering of a particular cell. 
		/// </summary>
		/// <param name="block">The delegate to invoke</param>
		/// <returns>The grid column builder.</returns>
		INestedGridColumnBuilder<T> Do(Action<T> block);
	}
}