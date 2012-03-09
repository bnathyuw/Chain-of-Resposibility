using CoinSorter;
using CoinSorter.CoinIdentifiers;
using CoinSorter.Coins;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
	[TestFixture]
	public class SorterTests
	{
		private ICoinIdentifier _coinIdentifier;
		private Sorter _sorter;

		[SetUp]
		public void SetUp() {
			_coinIdentifier = MockRepository.GenerateStub<ICoinIdentifier>();
			_sorter = new Sorter(_coinIdentifier);
		}

		[Test]
		public void Calls_coin_identifier() {
			var coinInput = new CoinInput();

			_sorter.Sort(coinInput);

			_coinIdentifier.AssertWasCalled(i => i.Identify(coinInput));
		}

		[Test]
		public void Returns_value_from_identifier() {
			var coinInput = new CoinInput();
			var coin = new Coin();
			_coinIdentifier.Stub(i => i.Identify(coinInput)).Return(coin);

			Coin result = _sorter.Sort(coinInput);

			Assert.That(result, Is.EqualTo(coin));
		}
	}
}