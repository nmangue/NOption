using System.Collections.Generic;
using Xunit;

namespace NOption.Tests
{
	public class Option_As_Should
	{
		List<string> value = new List<string>() { "a", "b", "c" };

		[Fact]
		public void CastContent_WhenSome_AndTypeIsAssignable()
		{
			Option<List<string>> optionValue = value;

			var optionEnumerable = optionValue.As<IEnumerable<string>>();

			Assert.True(optionEnumerable.HasSome(out var optionV));
			Assert.Equal(value, optionV);
		}

		[Fact]
		public void ReturnNone_WhenSome_ButTypeCantBeAssigned()
		{
			Option<List<string>> optionValue = value;

			var optionString = optionValue.As<string>();

			Assert.Equal(Option.None, optionString);
		}

		[Fact]
		public void StillBeNone_WhenNone()
		{
			Option<int> none = Option.None;

			var optionString = none.As<string>();

			Assert.Equal(Option.None, optionString);
		}
	}
}
