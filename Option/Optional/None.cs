﻿using System;

namespace CodingHelmet.Optional
{
  public sealed class None : IEquatable<None>
  {
    internal static None Value { get; } = new None();

    private None() { }

    public override bool Equals(object obj) =>
        !(obj is null) && ((obj is None) || this.IsGenericNone(obj.GetType()));

    private bool IsGenericNone(Type type) =>
        type.GenericTypeArguments.Length == 1 &&
        typeof(None<>).MakeGenericType(type.GenericTypeArguments[0]) == type;

    public bool Equals(None other) => true;

    public override int GetHashCode() => 0;

    public override string ToString() => nameof(None);
  }
}
