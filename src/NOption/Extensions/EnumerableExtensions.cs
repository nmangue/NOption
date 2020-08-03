using System;
using System.Collections.Generic;
using System.Linq;

namespace NOption.Extensions
{
	public static class EnumerableExtensions
	{
		public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
				sequence.Select(x => OptionImpl<T>.Some(x))
						.DefaultIfEmpty(OptionImpl<T>.None)
						.First();

		public static Option<T> FirstOrNone<T>(
				this IEnumerable<T> sequence, Func<T, bool> predicate) =>
				sequence.Where(predicate).FirstOrNone();

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
