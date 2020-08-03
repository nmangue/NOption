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
			Option<List<string>> optionValue = Option.Some(value);

			var optionEnumerable = optionValue.As<IEnumerable<string>>();

			Assert.True(optionEnumerable.HasSome(out var optionV));
			Assert.Equal(value, optionV);
		}

		[Fact]
		public void ReturnNone_WhenSome_ButTypeCantBeAssigned()
		{
			Option<List<string>> optionValue = Option.Some(value);

			var optionString = optionValue.As<string>();

			Assert.Equal(Option.None<string>(), optionString);
		}

		[Fact]
		public void StillBeNone_WhenNone()
		{
			Option<int> none = Option.None<int>();

			var optionString = none.As<string>();

			Assert.Equal(Option.None<string>(), optionString);
		}
	}
}
