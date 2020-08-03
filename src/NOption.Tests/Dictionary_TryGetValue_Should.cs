using System.Collections.Generic;
using Xunit;
using NOption.Extensions;

namespace NOption.Tests
{
	public class Dictionary_TryGetValue_Should
	{
		private readonly Dictionary<string, int> someDic;

		public Dictionary_TryGetValue_Should()
		{
			someDic = new Dictionary<string, int>();
			someDic.Add("a", 1);
			someDic.Add("b", 2);
			someDic.Add("c", 3);
		}

		[Fact]
		public void ReturKeyValue_WhenKeyExists()
		{
			var result = someDic.TryGetValue("b");

			result.Match(
					Some: v => Assert.Equal(2, v),
					None: () => CustomAssert.Fail()
					);
		}

		[Fact]
		public void ReturnNone_WhenKeyNotInDictionary()
		{
			var result = someDic.TryGetValue("d");

			result.Match(
					Some: v => CustomAssert.Fail(),
					None: () => { } // Pass
					);
		}
	}
}
