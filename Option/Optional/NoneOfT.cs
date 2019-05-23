using System;

namespace Standard.Options
{
  public sealed class None<T> : Option<T>, IEquatable<None<T>>, IEquatable<None>
  {
    public override void Match(Action<T> some, Action none) => none();

    public override T Unwrap() => throw new InvalidOperationException();

    public override T UnwrapOr(T value) => value;

    public override T UnwrapOr(Func<T> f) => f();

    public override Option<TResult> Map<TResult>(Func<T, TResult> map) => None.Value;

    public override Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> map) => None.Value;

    public override Option<TNew> As<TNew>() => Option.None;

    public override string ToString() => "None";

    public override bool Equals(object obj) =>
        !(obj is null) && ((obj is None<T>) || (obj is None));

    public bool Equals(None<T> other) => true;

    public bool Equals(None other) => true;

    public override int GetHashCode() => 0;

    public static bool operator ==(None<T> a, None<T> b) =>
        (a is null && b is null) ||
        (!(a is null) && a.Equals(b));

    public static bool operator !=(None<T> a, None<T> b) => !(a == b);
  }
}
