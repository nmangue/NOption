using System;
using Xunit;

namespace NOption.Tests
{
    public class Option_Unwrap_Should
    {
        [Fact]
        public void ReturnContent_WhenSome()
        {
            var callResult = TestFunctions.CallWithSomeValue();
            
            Assert.Equal(TestFunctions.CallValue, callResult.Unwrap());
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenNone()
        {
            var callResult = TestFunctions.CallWithNone();

            Assert.Throws<InvalidOperationException>(() => callResult.Unwrap());
        }
    }
}
