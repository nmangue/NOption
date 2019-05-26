using System;
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

            var someMapResult = mapResult as Some<string>;
            Assert.NotNull(someMapResult);
            Assert.Equal(TestFunctions.CallValue.ToString(), someMapResult.Content);
        }

        [Fact]
        public void ReturnNone_WhenNone()
        {
            var callResult = TestFunctions.CallWithNone();

            var mapResult = callResult.FlatMap(ToOptionString);

            Assert.Equal(Option.None, mapResult);
        }

        private Option<string> ToOptionString(int value)
        {
            return value.ToString();
        }
    }
}
