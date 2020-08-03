using Xunit;

namespace NOption.Tests
{
	public class Option_FlatMap_Should
	{
		[Fact]
		public void ReturnFunctionResult_WhenSome()
		{
			var callResult = TestFunctions.CallWithSomeValue();

			var mapResult = callResult.FlatMap(ToOptionString);

			Assert.True(mapResult.HasSome(out var value));
			Assert.Equal(TestFunctions.CallValue.ToString(), value);
		}

		[Fact]
		public void ReturnNone_WhenNone()
		{
			var callResult = TestFunctions.CallWithNone();

			var mapResult = callResult.FlatMap(ToOptionString);

			Assert.Equal(Option.None<string>(), mapResult);
		}

		[Fact]
		public void BeCompatible_WithIOption()
		{
			Option<int> Twice(int other)
			{
				return Option.Some(other * 2);
			}

			var result = TestFunctions.CallWithSomeValue().FlatMap(Twice);

			Assert.True(result.HasSome(out var value));
			Assert.Equal(84, value);
		}

		private Option<string> ToOptionString(int value)
		{
			return Option.Some(value.ToString());
		}
	}
}
