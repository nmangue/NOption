using Xunit;

namespace NOption.Tests
{
	public class Option_Should
	{
		[Fact]
		public void BeWrapped_AsSome_FromValue()
		{
			var callResult = TestFunctions.CallWithSomeValue();

			Assert.True(callResult.HasSome(out var value));
			Assert.Equal(42, value);
		}

		[Fact]
		public void BeWrapped_AsNone_FromGenericNone()
		{
			var callResult = TestFunctions.CallWithNone();

			Assert.False(callResult.HasSome(out var value));
		}

		[Fact]
		public void TestMyStuff()
		{
			Chronique<string> x = new MyStuff<string>();
			Chronique<object> y = x;

			y.ValeurA();

		}
	}

	public interface Chronique<out TValeur>
	{
		IOption<TValeur> ValeurA();
	}

	public class MyStuff<T> : Chronique<T>
	{
		public IOption<T> ValeurA()
		{
			return Option<T>.None;
		}
	}
}
