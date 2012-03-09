using Console;
using Console.CoinChecks;
using Console.Coins;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
	[TestFixture]
	public class CoinDiameterCheckTests
	{
		private CoinDiameterCheck _coinDiameterCheck;
		private ICoinCheck _successor;

		[SetUp]
		public void SetUp() {
			_successor = MockRepository.GenerateStub<ICoinCheck>();
			_coinDiameterCheck = new CoinDiameterCheck(_successor);
		}

		[Test]
		public void Calls_successor_if_diameter_is_the_same() {
			var coinInput = new CoinInput {Diameter = 12};
			var coinSpec = new CoinInput {Diameter = 12};
			
			_coinDiameterCheck.CheckCoin(coinInput, coinSpec);
			
			_successor.AssertWasCalled(s => s.CheckCoin(coinInput, coinSpec));
		}

		[Test]
		public void Returns_result_from_successor_if_diameter_is_the_same() {
			var coinInput = new CoinInput { Diameter = 12 };
			var coinSpec = new CoinInput { Diameter = 12 };
			_successor.Stub(s => s.CheckCoin(coinInput, coinSpec)).Return(false);

			var result = _coinDiameterCheck.CheckCoin(coinInput, coinSpec);

			Assert.That(result, Is.False);
		}

		[Test]
		public void Returns_false_if_diameter_is_different() {
			var result = _coinDiameterCheck.CheckCoin(new CoinInput { Diameter = 12 }, new CoinInput { Diameter = 1.2 });
			Assert.That(result, Is.False);
		}
	}
}