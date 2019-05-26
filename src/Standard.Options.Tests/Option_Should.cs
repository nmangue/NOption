using Xunit;

namespace Standard.Options.Tests
{
    public class Option_Should
    {
        [Fact]
        public void BeWrapped_AsSome_FromValue()
        {
            var callResult = TestFunctions.CallWithSomeValue();

            var someResult = callResult as Some<int>;

            Assert.NotNull(someResult);
            Assert.Equal(42, someResult.Content);
        }

        [Fact]
        public void BeWrapped_AsNone_FromGenericNone()
        {
            var callResult = TestFunctions.CallWithNone();

            Assert.True(callResult is None<int>);
        }
    }
}
