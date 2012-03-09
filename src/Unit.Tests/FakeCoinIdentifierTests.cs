using CoinSorter.CoinIdentifiers;
using CoinSorter.Coins;
using NUnit.Framework;

namespace Unit.Tests
{
	[TestFixture]
	public class FakeCoinIdentifierTests
	{
		private FakeCoinIdentifier _fakeCoinIdentifier;

		[SetUp]
		public void SetUp() {
			_fakeCoinIdentifier = new FakeCoinIdentifier();
		}

		[Test]
		public void Always_returns_fake() {
			Coin result = _fakeCoinIdentifier.Identify(new CoinInput());

			Assert.That(result.Value, Is.EqualTo("fake"));
		}
	}
}