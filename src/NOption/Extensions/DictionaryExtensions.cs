using System.Collections.Generic;

namespace NOption.Extensions
{
	public static class DictionaryExtensions
	{
		public static Option<TValue> TryGetValue<TKey, TValue>(
				this IDictionary<TKey, TValue> dictionary, TKey key) =>
				dictionary.TryGetValue(key, out TValue value)
						? OptionImpl<TValue>.Some(value)
						: OptionImpl<TValue>.None;
	}
}
