namespace NOption
{
	/// <summary>
	/// Provides sugar coating methods to work with <see cref="Option{T}"/>.
	/// </summary>
	public static class Option
	{
		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/>.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> Some<T>(T value) => value;

		/// <summary>
		/// Option instance with no value.
		/// </summary>
		public static None None => None.Value;
	}
}
