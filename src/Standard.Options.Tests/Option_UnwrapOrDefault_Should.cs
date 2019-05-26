using Xunit;

namespace Standard.Options.Tests
{
    public class Option_UnwrapOrDefault_Should
    {
        [Fact]
        public void ReturnContent_WhenSome()
        {
            var callResult = TestFunctions.CallWithSomeValue();
            
            Assert.Equal(TestFunctions.CallValue, callResult.UnwrapOrDefault());
        }

        [Fact]
        public void ReturnDefaultValue_WhenNone()
        {
            int defaultIntValue = default;
            var callResult = TestFunctions.CallWithNone();

            Assert.Equal(defaultIntValue, callResult.UnwrapOrDefault());
        }
    }
}
