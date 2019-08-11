namespace NOption.Tests
{
	static class TestFunctions
	{
		internal const int CallValue = 42;

		internal static Option<int> CallWithSomeValue()
		{
			return CallValue;
		}

		internal static Option<int> CallWithNone()
		{
			return Option.None;
		}
	}
}
