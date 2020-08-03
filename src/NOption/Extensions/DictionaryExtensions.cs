using System.Collections.Generic;

namespace NOption.Extensions
{
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Gets the value that is associated with the specified key.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="dictionary">A dictionary to get a value from.</param>
		/// <param name="key">The key to locate.</param>
		/// <returns>An option with the value associated with the specified key, if the key is found; otherwise, an option with no value.</returns>
		public static Option<TValue> TryGetValue<TKey, TValue>(
				this IDictionary<TKey, TValue> dictionary, TKey key) =>
				dictionary.TryGetValue(key, out TValue value)
						? OptionImpl<TValue>.Some(value)
						: OptionImpl<TValue>.None;
	}
}
