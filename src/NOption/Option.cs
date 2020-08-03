using System;

namespace NOption
{
	/// <summary>
	/// Provides methods to work with <see cref="Option{T}"/>.
	/// </summary>
	public static class Option
	{
		/// <summary>
		/// Option instance with no value.
		/// </summary>
		public static Option<T> None<T>() => OptionImpl<T>.None;

		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/>.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> Some<T>(T value) => OptionImpl<T>.Some(value);

		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/> if <paramref name="when"/> is <c>true</c>.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <param name="when">Indicates whether the result should be something or none. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> Some<T>(T obj, bool when) => when ? OptionImpl<T>.Some(obj) : OptionImpl<T>.None;

		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/> if <paramref name="when"/> is <c>true</c>.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <param name="when">Indicates whether the result should be something or none. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> Some<T>(T obj, Func<bool> when) => Some(obj, when());

		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/> if <paramref name="when"/> is <c>true</c>.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <param name="when">Indicates whether the result should be something or none. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> Some<T>(T obj, Func<T, bool> when) => Some(obj, when(obj));

		/// <summary>
		/// Wraps the specified value in an instance of <see cref="Option{T}"/> if <paramref name="value"/> is not null.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static Option<T> SomeIfNotNull<T>(T value) where T : class => value != null ? OptionImpl<T>.Some(value) : OptionImpl<T>.None;
	}
}
