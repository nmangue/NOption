using Xunit;

namespace NOption.Tests
{
    public class Option_HasSome_Should
    {
        [Fact]
        public void ReturnValue_WhenSome()
        {
            var callResult = TestFunctions.CallWithSomeValue();

						Assert.True(callResult.HasSome(out var result));

						Assert.Equal(TestFunctions.CallValue, result);
        }

        [Fact]
        public void ReturnFalse_WhenNone()
        {
            var callResult = TestFunctions.CallWithNone();

						Assert.False(callResult.HasSome(out var result));

						Assert.Equal(default, result);
        }
    }
}
