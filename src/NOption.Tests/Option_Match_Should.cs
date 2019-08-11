using Xunit;

namespace NOption.Tests
{
	public class Option_Match_Should
	{
		[Fact]
		public void CallActionForSome_WhenSome()
		{
			var someActionCalls = 0;
			var callResult = TestFunctions.CallWithSomeValue();

			callResult.Match(
					Some: (x) => { Assert.Equal(TestFunctions.CallValue, x); someActionCalls++; },
					None: () => CustomAssert.Fail()
					);

			// Check that the some action is called only once
			CustomAssert.EqualOne(someActionCalls);
		}

		[Fact]
		public void CallActionForNone_WhenNone()
		{
			var noneActionCalls = 0;
			var callResult = TestFunctions.CallWithNone();

			callResult.Match(
					Some: (x) => CustomAssert.Fail(),
					None: () => noneActionCalls++
					);

			// Check that the none action is called only once
			CustomAssert.EqualOne(noneActionCalls);
		}
	}
}
