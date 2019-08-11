using System;
using System.Collections.Generic;
using System.Linq;

namespace NOption.Extensions
{
	public static class EnumerableExtensions
	{
		public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
				sequence.Select(x => Option.Some(x))
						.DefaultIfEmpty(Option.None)
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

	}
}
