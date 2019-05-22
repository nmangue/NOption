﻿using System;

namespace CodingHelmet.Optional
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();

        public abstract T Unwrap();

        public abstract T UnwrapOr(T value);

        public T UnwrapOrDefault()
        {
            return UnwrapOr(default(T));
        }

        public abstract void Match(Action<T> some, Action none);

        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);
        public abstract Option<TResult> FlatMap<TResult>(Func<T, Option<TResult>> map);
        public abstract T Reduce(T whenNone);
        public abstract T Reduce(Func<T> whenNone);

        public Option<TNew> As<TNew>() where TNew : class =>
            this is Some<T> some && typeof(TNew).IsAssignableFrom(typeof(T))
                ? (Option<TNew>)new Some<TNew>(some.Content as TNew)
                : None.Value;
    }
}
