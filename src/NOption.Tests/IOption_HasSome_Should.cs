using Xunit;

namespace NOption.Tests
{
	public class IOption_HasSome_Should
	{
		[Fact]
		public void ReturnValue_WhenSome()
		{
			var callResult = TestFunctions.IOptionCallWithSomeValue();

			Assert.True(callResult.HasSome(out var result));

			Assert.Equal(TestFunctions.CallValue, result);
		}

		[Fact]
		public void ReturnFalse_WhenNone()
		{
			var callResult = TestFunctions.IOptionCallWithNone();

			Assert.False(callResult.HasSome(out var result));

			Assert.Equal(default, result);
		}
	}
}
