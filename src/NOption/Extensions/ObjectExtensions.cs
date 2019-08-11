using System;

namespace NOption.Extensions
{
	public static class ObjectExtensions
	{
		public static Option<T> When<T>(this T obj, bool condition) =>
				condition ? Option.Some(obj) : Option<T>.None;

		public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
				obj.When(predicate(obj));

		public static Option<T> NoneIfNull<T>(this T obj) =>
				obj.When(!object.ReferenceEquals(obj, null));
	}
}
