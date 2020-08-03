namespace NOption.Tests
{
	static class TestFunctions
	{
		internal const int CallValue = 42;

		internal static Option<int> CallWithSomeValue()
		{
			return Option.Some(CallValue);
		}

		internal static Option<int> CallWithNone()
		{
			return Option.None<int>();
		}


		internal static Option<int> IOptionCallWithSomeValue()
		{
			return Option.Some(CallValue);
		}

		internal static Option<int> IOptionCallWithNone()
		{
			return Option.None<int>();
		}
	}
}
