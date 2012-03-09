using CoinSorter.CoinChecks;
using CoinSorter.Coins;
using NUnit.Framework;

namespace Unit.Tests
{
	[TestFixture]
	public class PassCoinCheckTests
	{
		[Test]
		public void Returns_false() {
			bool result = new PassCoinCheck().CheckCoin(new CoinInput(), new CoinInput());
			Assert.That(result, Is.True);
		}
	}
}