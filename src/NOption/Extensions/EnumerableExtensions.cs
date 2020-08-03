using System;
using System.Collections.Generic;
using System.Linq;

namespace NOption.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Returns the first element of a sequence, or an option with no value if the sequence contains no elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <paramref name="sequence"/></typeparam>
		/// <param name="sequence">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
		/// <returns>Option with no value if <paramref name="sequence"/> is empty; otherwise, the first element in <paramref name="sequence"/>.</returns>
		public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
				sequence.Select(x => Option.Some(x))
						.DefaultIfEmpty(Option.None<T>())
						.First();

		/// <summary>
		/// Returns the first element of the sequence that satisfies a condition or an option with no value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <paramref name="sequence"/></typeparam>
		/// <param name="sequence">The <see cref="IEnumerable{T}"/> to return an element from.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>Option with no value if <paramref name="sequence"/> is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the first element in source that passes the test specified by <paramref name="predicate"/></returns>
		public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence, Func<T, bool> predicate) =>
				sequence.Where(predicate).FirstOrNone();

		/// <summary>
		/// Projects each element of a sequence into a new form.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <paramref name="sequence"/>.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="map"/>.</typeparam>
		/// <param name="sequence">A sequence of values to invoke a transform function on.</param>
		/// <param name="map">A transform function to apply to each element.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of source which have a value.</returns>
		public static IEnumerable<TResult> SelectSome<T, TResult>(
				this IEnumerable<T> sequence, Func<T, Option<TResult>> map)
		{
			foreach (var item in sequence)
			{
				if (map(item).HasSome(out var result))
				{
					yield return result;
				}
			}
		}

		/// <summary>
		/// Returns the first option with a value of an option sequence, or an option with no value if the sequence contains no option with a value or no elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <paramref name="sequence"/></typeparam>
		/// <param name="sequence">The <see cref="IEnumerable{T}"/> to return the first option with a value of.</param>
		/// <returns>Option with no value if <paramref name="sequence"/> is empty or no option with a value; otherwise, the first option with a value in <paramref name="sequence"/>.</returns>

		public static Option<T> FirstSome<T>(this IEnumerable<Option<T>> sequence)
		{
			foreach (var item in sequence)
			{
				if (item.HasSome(out var result))
				{
					return Option.Some(result);
				}
			}
			return Option.None<T>();
		}

		/// <summary>
		/// Returns the first option with a value of an option sequence that satisfies a condition, or an option with no value if no such element is found.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <paramref name="sequence"/></typeparam>
		/// <param name="sequence">The <see cref="IEnumerable{T}"/> to return the first option with a value of.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>Option with no value if <paramref name="sequence"/> is empty or if no element passes the test specified by <paramref name="predicate"/>; 
		/// otherwise, the first option with a value in <paramref name="sequence"/> that passes the test specified by <paramref name="predicate"/>.</returns>

		public static Option<T> FirstSome<T>(this IEnumerable<Option<T>> sequence, Func<T, bool> predicate)
		{
			foreach (var item in sequence)
			{
				if (item.HasSome(out var result) && predicate(result))
				{
					return Option.Some(result);
				}
			}
			return Option.None<T>();
		}
	}
}
