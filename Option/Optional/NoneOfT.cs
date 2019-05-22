using System;

namespace CodingHelmet.Optional
{
  public sealed class None<T> : Option<T>, IEquatable<None<T>>, IEquatable<None>
  {
    public override Option<TResult> Map<TResult>(Func<T, TResult> map) =>
        None.Value;

    public override Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) =>
        None.Value;

    public override T Reduce(T whenNone) =>
        whenNone;

    public override T Reduce(Func<T> whenNone) =>
        whenNone();

    public override bool Equals(object obj) =>
        !(obj is null) && ((obj is None<T>) || (obj is None));

    public override int GetHashCode() => 0;

    public bool Equals(None<T> other) => true;

    public bool Equals(None other) => true;

    public static bool operator ==(None<T> a, None<T> b) =>
        (a is null && b is null) ||
        (!(a is null) && a.Equals(b));

    public static bool operator !=(None<T> a, None<T> b) => !(a == b);

    public override string ToString() => "None";
  }
}
