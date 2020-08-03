using System;
using System.Collections.Generic;

namespace NOption
{
	/// <summary>
	/// Represents an object that can have some value of type <typeparamref name="T"/>, or none.
	/// </summary>
	/// <typeparam name="T">Type of the wrapped value.</typeparam>
	internal readonly struct OptionImpl<T> : IEquatable<OptionImpl<T>>, Option<T>
	{
		/// <summary>
		/// Wrapped value, if the option has some.
		/// </summary>
		/// <remarks>
		/// Defined at <c>default</c> if none.
		/// </remarks>
		private readonly T _value;

		/// <summary>
		/// Indicates whether the option has a value.
		/// </summary>
		private readonly bool _hasSome;

		/// <summary>
		/// Wraps the specified value in an option.
		/// </summary>
		/// <param name="value">The value to be wrapped in an option. (Can be <c>null</c>)</param>
		/// <returns>An option wrapping the value.</returns>
		public static OptionImpl<T> Some(T value)
		{
			return new OptionImpl<T>(true, value);
		}

		/// <summary>
		/// Option instance with no value.
		/// </summary>
		public static OptionImpl<T> None { get; } = new OptionImpl<T>();

		private OptionImpl(bool hasSome = false, T value = default)
		{
			_hasSome = hasSome;
			_value = _hasSome ? value : default;
		}

		/// <summary>
		/// Executes the action <paramref name="Some"/> with the option value, if any.
		/// Does nothing if the option has no value.
		/// </summary>
		/// <param name="Some">Action to execute on the option value if some.</param>
		public void Match(Action<T> Some)
		{
			Match(Some, () => { });
		}

		/// <summary>
		/// Executes the action <paramref name="Some"/> or <paramref name="None"/> whether the option has a value or not.
		/// </summary>
		/// <param name="Some">Action to execute with the option value, if the option has one.</param>
		/// <param name="None">Action to execute if the option has no value.</param>
		public void Match(Action<T> Some, Action None)
		{
			if (_hasSome)
			{
				Some(_value);
			}
			else
			{
				None();
			}
		}

		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <exception cref="InvalidOperationException">The option has no value.</exception>
		/// <returns>Option value if any.</returns>
		public T UnwrapOrFailure()
		{
			return _hasSome ? _value : throw new InvalidOperationException("This Option has no value");
		}

		/// <summary>
		/// Gets the value wrapped by the option if any. Otherwise, returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="defaultValue">Returned value if the option has no value.</param>
		/// <returns>Option value if any; otherwise, <paramref name="defaultValue"/>.</returns>
		public T UnwrapOr(T defaultValue)
		{
			return _hasSome ? _value : defaultValue;
		}

		/// <summary>
		/// Gets the value wrapped by the option if any. Otherwise, executes and returns <paramref name="f"/>
		/// </summary>
		/// <remarks>
		/// <paramref name="f"/> is not called if the option has a value.
		/// </remarks>
		/// <param name="f">Function to be executed and returned if the option has no value</param>
		/// <returns>Option value if any; otherwise, <paramref name="f"/> call result.</returns>
		public T UnwrapOr(Func<T> f)
		{
			return _hasSome ? _value : f();
		}

		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <param name="value">When this method returns, contains the value wrapped by the option, if any; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
		/// <returns><c>true</c> if the option has a value; otherwise, <c>false</c>.</returns>
		public bool HasSome(out T value)
		{
			if (_hasSome)
			{
				value = _value;
				return true;
			}

			value = default;
			return false;
		}

		/// <summary>
		/// Gets the value wrapped by the option.
		/// </summary>
		/// <returns>The value wrapped by the option, if any; otherwise, the default value for the type of the value parameter.</returns>
		public T UnwrapOrDefault()
		{
			return UnwrapOr(default(T));
		}

		/// <summary>
		/// Projects the option value into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="map"/>.</typeparam>
		/// <param name="map">A transform function to apply to the option value.</param>
		/// <returns>The result of invoking the transform function with the option value, if any; otherwhise <c>None</c></returns>
		public Option<TResult> Map<TResult>(Func<T, TResult> map)
		{
			return _hasSome ? OptionImpl<TResult>.Some(map(_value)) : OptionImpl<TResult>.None;
		}

		/// <summary>
		/// Projects the option value into a new form.
		/// </summary>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="map"/>.</typeparam>
		/// <param name="map">A transform function to apply to the option value.</param>
		/// <returns>The result of invoking the transform function with the option value, if any; otherwhise <c>None</c></returns>
		public Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> map)
		{
			return _hasSome ? map(_value) : OptionImpl<TResult>.None;
		}


		/// <summary>
		/// Returns the option value typed as <typeparamref name="TNew"/>.
		/// </summary>
		/// <typeparam name="TNew">The target type.</typeparam>
		/// <returns>An option wrapping the same value as <typeparamref name="TNew"/>, if any; otherwise, <c>None</c></returns>
		public Option<TNew> As2<TNew>()
		{
			var x = _value is TNew newValue ? newValue : default;
			return _hasSome && typeof(TNew).IsAssignableFrom(typeof(T))
								? new OptionImpl<TNew>(true, x)
								: OptionImpl<TNew>.None;
		}

		/// <summary>
		/// Returns the option value typed as <typeparamref name="TNew"/>.
		/// </summary>
		/// <typeparam name="TNew">The target type.</typeparam>
		/// <returns>An option wrapping the same value as <typeparamref name="TNew"/>, if any; otherwise, <c>None</c></returns>
		public Option<TNew> As<TNew>() where TNew : class
		{
			var x = _value is TNew newValue ? newValue : null;
			return _hasSome && typeof(TNew).IsAssignableFrom(typeof(T))
								? new OptionImpl<TNew>(true, _value as TNew)
								: OptionImpl<TNew>.None;
		}

		public override bool Equals(object other)
		{
			return (other is OptionImpl<T> otherOption) && Equals(otherOption);
		}

		public bool Equals(OptionImpl<T> other)
		{
			if (_hasSome && other._hasSome)
			{
				return EqualityComparer<T>.Default.Equals(_value, other._value);
			}

			return !_hasSome && !other._hasSome;
		}

		public override int GetHashCode()
		{
			return _hasSome ? EqualityComparer<T>.Default.GetHashCode(_value) : 0;
		}

		//public static implicit operator OptionImpl<T>(T value) => Some(value);

		//public static implicit operator OptionImpl<T>(None _) => None;

		public override string ToString() => _hasSome ? $"Some({ValueToString})" : "None";

		private string ValueToString => _value?.ToString() ?? "<null>";
	}
}
