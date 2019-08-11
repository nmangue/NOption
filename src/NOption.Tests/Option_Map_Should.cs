using Xunit;

namespace NOption.Tests
{
	public class Option_Map_Should
	{
		[Fact]
		public void ReturnFunctionResult_WhenSome()
		{
			var callResult = TestFunctions.CallWithSomeValue();

			var mapResult = callResult.Map(x => x.ToString());

			Assert.True(mapResult.HasSome(out var value));
			Assert.Equal(TestFunctions.CallValue.ToString(), value);
		}

		[Fact]
		public void CallFunctionWithContent_WhenSome()
		{
			var callResult = TestFunctions.CallWithSomeValue();
			int mapParameterValue = default;
			var mapResult = callResult.Map((x) =>
			{
				mapParameterValue = x;
				return x.ToString();
			});

			Assert.Equal(TestFunctions.CallValue, mapParameterValue);
		}

		[Fact]
		public void ReturnNone_WhenNone()
		{
			var callResult = TestFunctions.CallWithNone();

			var mapResult = callResult.Map(x => x.ToString());

			Assert.Equal(Option.None, mapResult);
		}
	}
}
