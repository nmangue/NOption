namespace CodingHelmet.Optional
{
    public static class Option
    {
      public static Some<T> Some<T>(T value) => new Some<T>(value);
      public static None None => None.Value;
    }
}
