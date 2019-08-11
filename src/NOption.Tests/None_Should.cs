using System;
using System.Collections.Generic;
using Xunit;

namespace NOption.Tests
{
	public class None_Should
	{
		public static IEnumerable<object[]> NoneOptions =>
				new List<object[]>
				{
								new object[] { Option<int>.None },
								new object[] { Option<string>.None },
								new object[] { Option<Exception>.None }
				};

		public static IEnumerable<object[]> SomeOptions =>
				new List<object[]>
				{
								new object[] { Option<int>.Some(42) },
								new object[] { Option<string>.Some("Hello") },
								new object[] { Option<Exception>.Some(new Exception("Test")) }
				};

		[Theory]
		[MemberData(nameof(NoneOptions))]
		public void BeEqual_ToAnyOptionWithNoValue(object optionNone)
		{
			Assert.Equal(Option.None, optionNone);
		}

		[Theory]
		[MemberData(nameof(NoneOptions))]
		public void BeEqual_ToAnyOptionWithNoValue_Equivalent(object optionNone)
		{
			Assert.Equal(optionNone, Option.None);
		}

		[Theory]
		[MemberData(nameof(SomeOptions))]
		public void NotBeEqual_ToAnyOptionWithAValue(object optionNone)
		{
			Assert.NotEqual(Option.None, optionNone);
		}

		[Theory]
		[MemberData(nameof(SomeOptions))]
		public void NotBeEqual_ToAnyOptionWithAValue_Equivalent(object optionNone)
		{
			Assert.NotEqual(optionNone, Option.None);
		}
	}
}
