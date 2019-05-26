using Xunit;

namespace NOption.Tests
{
    static class CustomAssert
    {
        public static void Fail() => Fail("Test failed deliberately");
        public static void Fail(string message) => Assert.True(false, message);
        public static void EqualOne(int actualValue) => Assert.Equal(1, actualValue);
        public static void EqualZero(int actualValue) => Assert.Equal(0, actualValue);
    }
}
