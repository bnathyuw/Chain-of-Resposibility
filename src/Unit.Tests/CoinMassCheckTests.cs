using Console;
using Console.CoinChecks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests {
	[TestFixture]
	public class CoinMassCheckTests
	{
		private CoinMassCheck _coinMassCheck;
		private ICoinCheck _successor;

		[SetUp]
		public void SetUp() {
			_successor = MockRepository.GenerateStub<ICoinCheck>();
			_coinMassCheck = new CoinMassCheck(_successor);
		}

		[Test]
		public void Calls_successor_if_mass_is_the_same() {
			var coinInput = new CoinInput {Mass = 1};
			var coinSpec = new CoinInput {Mass = 1};
			
			_coinMassCheck.CheckCoin(coinInput, coinSpec);

			_successor.AssertWasCalled(x => x.CheckCoin(coinInput, coinSpec));
		}

		[Test]
		public void Calls_successor_if_mass_is_less_than_one_percent_more() {
			var coinInput = new CoinInput {Mass = 1.001};
			var coinSpec = new CoinInput {Mass = 1};
			
			_coinMassCheck.CheckCoin(coinInput, coinSpec);

			_successor.AssertWasCalled(x => x.CheckCoin(coinInput, coinSpec));
		}

		[Test]
		public void Calls_successor_if_mass_is_less_than_one_percent_less() {
			var coinInput = new CoinInput {Mass = 0.999};
			var coinSpec = new CoinInput {Mass = 1};

			_coinMassCheck.CheckCoin(coinInput, coinSpec);

			_successor.AssertWasCalled(x => x.CheckCoin(coinInput, coinSpec));
		}

		[Test]
		public void Returns_false_if_mass_is_very_different() {
			var coinInput = new CoinInput {Mass = 1};
			var coinSpec = new CoinInput {Mass = 12};

			var result = _coinMassCheck.CheckCoin(coinInput, coinSpec);

			Assert.That(result, Is.False);
		}

		[Test]
		public void Returns_result_from_successor_if_mass_is_the_same() {
			var coinInput = new CoinInput { Mass = 1 };
			var coinSpec = new CoinInput { Mass = 1 };
			_successor.Stub(x => x.CheckCoin(coinInput, coinSpec)).Return(false);

			var result = _coinMassCheck.CheckCoin(coinInput, coinSpec);

			Assert.That(result, Is.False);
		}
	}
}
