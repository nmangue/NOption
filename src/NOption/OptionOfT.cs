using System;

namespace NOption
{
	/// <summary>
	/// Interface for an object that can have some value of type <typeparamref name="T"/>, or none.
	/// </summary>
	/// <typeparam name="T">Type of the wrapped value.</typeparam>
	public interface Option<out T>
	{
		/// <summary>
		/// Executes the action <paramref name="Some"/> with the option value, if any.
		/// Does nothing if the option has no value.
		/// </summary>
		/// <param name="Some">Action to execute on the option value if some.</param>
		void Match(Action<T> Some);

		/// <summary>
		/// Executes the action <paramref name="Some"/> or <paramref name="None"/> whether the option has a value or not.
		/// </summary>
		/// <param name="Some">Action to execute with the option value, if the option has one.</param>
		/// <param name="None">Action to execute if the option has no value.</param>
		void Match(Action<T> Some, Action None);

		/// <summary>
		/// Projects the option value into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="map"/>.</typeparam>
		/// <param name="map">A transform function to apply to the option value.</param>
		/// <returns>The result of invoking the transform function with the option value, if any; otherwhise <c>None</c></returns>
		Option<TResult> Map<TResult>(Func<T, TResult> map);

		/// <summary>
		/// Projects the option value into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="map"/>.</typeparam>
		/// <param name="map">A transform function to apply to the option value.</param>
		/// <returns>The result of invoking the transform function with the option value, if any; otherwhise <c>None</c></returns>
		Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> map);

		/// <summary>
		/// Returns the option value typed as <typeparamref name="TNew"/>.
		/// </summary>
		/// <typeparam name="TNew">The target type.</typeparam>
		/// <returns>An option wrapping the same value as <typeparamref name="TNew"/>, if any; otherwise, <c>None</c></returns>
		Option<TNew> As<TNew>();

		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <returns>The value wrapped by the option, if any; otherwise, the default value for the type of the value parameter.</returns>
		T UnwrapOrDefault();

		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <exception cref="InvalidOperationException">The option has no value.</exception>
		/// <returns>The value wrapped by the option, if any; otherwise, throws an exception.</returns>
		T UnwrapOrFailure();
	}
}
