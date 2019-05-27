namespace NOption
{
  public static class Option
  {
    public static Option<T> Some<T>(T value) => value;

    public static None None => None.Value;
  }
}
