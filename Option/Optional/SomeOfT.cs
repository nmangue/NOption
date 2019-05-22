using System;
using System.Collections.Generic;

namespace CodingHelmet.Optional
{
  public sealed class Some<T> : Option<T>, IEquatable<Some<T>>
  {
    internal T Content { get; }

    public Some(T value)
    {
      this.Content = value;
    }

    public static implicit operator T(Some<T> some) => some.Content;

    public static implicit operator Some<T>(T value) => new Some<T>(value);

    public override Option<TResult> Map<TResult>(Func<T, TResult> f) => f(Content);

    public override Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> f) => f(Content);

    public override T Unwrap() => Content;

    public override T UnwrapOr(T value) => Content;

    public override void Match(Action<T> some, Action none) => some(Content);
    

    public override string ToString() => $"Some({this.ContentToString})";

    private string ContentToString => this.Content?.ToString() ?? "<null>";

    public bool Equals(Some<T> other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return EqualityComparer<T>.Default.Equals(Content, other.Content);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj is Some<T> && Equals((Some<T>)obj);
    }

    public override int GetHashCode()
    {
      return EqualityComparer<T>.Default.GetHashCode(Content);
    }

    public override T UnwrapOr(Func<T> f) => Content;

    public static bool operator ==(Some<T> a, Some<T> b) =>
            (a is null && b is null) ||
            (!(a is null) && a.Equals(b));

    public static bool operator !=(Some<T> a, Some<T> b) => !(a == b);

    public override Option<TNew> As<TNew>() => 
           typeof(TNew).IsAssignableFrom(typeof(T))
                ? (Option<TNew>)new Some<TNew>(Content as TNew)
                : None.Value;
  }
}