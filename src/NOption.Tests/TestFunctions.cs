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


		internal static IOption<int> IOptionCallWithSomeValue()
		{
			return Option.Some(CallValue);
		}

		internal static IOption<int> IOptionCallWithNone()
		{
			return Option<int>.None;
		}
	}
}
