namespace Standard.Options
{
  public static class Option
  {
    public static Some<T> Some<T>(T value) => value;

    public static None None => None.Value;
  }
}