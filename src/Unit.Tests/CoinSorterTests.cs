using CoinSorter.CoinIdentifiers;
using CoinSorter.Coins;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
	[TestFixture]
	public class CoinSorterTests
	{
		private CoinSorter.CoinSorter _coinSorter;
		private ICoinIdentifier _coinIdentifier;

		[SetUp]
		public void SetUp() {
			_coinIdentifier = MockRepository.GenerateStub<ICoinIdentifier>();
			_coinSorter = new CoinSorter.CoinSorter(_coinIdentifier);
		}

		[Test]
		public void Calls_coin_identifier() {
			var coinInput = new CoinInput();
			
			_coinSorter.Sort(coinInput);

			_coinIdentifier.AssertWasCalled(i => i.Identify(coinInput));
		}

		[Test]
		public void Returns_value_from_identifier() {
			var coinInput = new CoinInput();
			var coin = new Coin();
			_coinIdentifier.Stub(i => i.Identify(coinInput)).Return(coin);

			var result = _coinSorter.Sort(coinInput);

			Assert.That(result, Is.EqualTo(coin));
		}
	}
}