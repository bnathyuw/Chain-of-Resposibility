using Console;
using Console.CoinChecks;
using Console.Coins;
using NUnit.Framework;

namespace Unit.Tests
{
	[TestFixture]
	public class PassCoinCheckTests
	{
		[Test]
		public void Returns_false() {
			var result = new PassCoinCheck().CheckCoin(new CoinInput(), new CoinInput());
			Assert.That(result, Is.True);
		}
	}
}