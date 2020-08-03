using System;

namespace NOption
{
	/// <summary>
	/// Extensions methods for <see cref="Option{T}"/>.
	/// </summary>
	/// <remarks>
	/// Those methods can not be declared within a covariant interface.
	/// </remarks>
	public static class OptionExtensions
	{
		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <param name="value">When this method returns, contains the value wrapped by the option, if any; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the option has a value; otherwise, <c>false</c>.</returns>
		public static bool HasSome<T>(this Option<T> option, out T value)
		{
			T result = default;
			bool hasSome = false;

			option.Match(v => { result = v; hasSome = true; });

			value = result;

			return hasSome;
		}

		/// <summary>
		/// Gets the value wrapped by the option if any. Otherwise, returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="defaultValue">Returned value if the option has no value.</param>
		/// <returns>Option value if any; otherwise, <paramref name="defaultValue"/>.</returns>
		public static T UnwrapOr<T>(this Option<T> option, T defaultValue)
		{
			return option.HasSome(out var value) ? value : defaultValue;
		}

		/// <summary>
		/// Gets the value wrapped by the option if any. Otherwise, executes and returns <paramref name="f"/>
		/// </summary>
		/// <remarks>
		/// <paramref name="f"/> is not called if the option has a value.
		/// </remarks>
		/// <param name="f">Function to be executed and returned if the option has no value</param>
		/// <returns>Option value if any; otherwise, <paramref name="f"/> call result.</returns>
		public static T UnwrapOr<T>(this Option<T> option, Func<T> f)
		{
			return option.HasSome(out var value) ? value : f();
		}
	}
}
