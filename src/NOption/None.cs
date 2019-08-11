using System;

namespace NOption
{
	/// <summary>
	/// Represent the None concept.
	/// </summary>
	public struct None : IEquatable<None>
	{
		internal static None Value { get; } = new None();

		public override bool Equals(object obj) =>
				!(obj is null) && ((obj is None) || IsGenericOption(obj.GetType())) && obj.Equals(this);

		private bool IsGenericOption(Type type) =>
				type.GenericTypeArguments.Length == 1 &&
				typeof(Option<>).MakeGenericType(type.GenericTypeArguments[0]) == type;

		public bool Equals(None other) => true;

		public override int GetHashCode() => 0;

		public override string ToString() => nameof(None);
	}
}
