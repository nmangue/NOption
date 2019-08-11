using Xunit;

namespace NOption.Tests
{
	public class Option_UnwrapOr_Should
	{
		const int OrValue = 24;

		[Fact]
		public void ReturnContent_WhenSome()
		{
			var callResult = TestFunctions.CallWithSomeValue();

			Assert.Equal(TestFunctions.CallValue, callResult.UnwrapOr(OrValue));
		}

		[Fact]
		public void ReturnOrValue_WhenNone()
		{
			var callResult = TestFunctions.CallWithNone();

			Assert.Equal(OrValue, callResult.UnwrapOr(OrValue));
		}

		[Fact]
		public void NotCallOrFunction_WhenSome()
		{
			ResetOrFunctionCalls();

			var callResult = TestFunctions.CallWithSomeValue();

			Assert.Equal(TestFunctions.CallValue, callResult.UnwrapOr(OrFunction));
			// Assert that OrFunction is never called
			CustomAssert.EqualZero(orFunctionCalls);
		}

		[Fact]
		public void ReturnOrFunctionResult_WhenNone()
		{
			ResetOrFunctionCalls();

			var callResult = TestFunctions.CallWithNone();

			Assert.Equal(OrValue, callResult.UnwrapOr(OrFunction));
			// Assert that OrFunction is called only once
			CustomAssert.EqualOne(orFunctionCalls);
		}

		int orFunctionCalls = 0;
		private int ResetOrFunctionCalls() => orFunctionCalls = 0;
		private int OrFunction()
		{
			orFunctionCalls++;
			return OrValue;
		}
	}
}
