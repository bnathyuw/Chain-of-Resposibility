using Console;
using Console.CoinChecks;
using NUnit.Framework;

namespace Unit.Tests {
	[TestFixture]
	public class CoinWeightCheckTests
	{
		private CoinWeightCheck _coinWeightCheck;

		[SetUp]
		public void SetUp() {
			_coinWeightCheck = new CoinWeightCheck();
		}
		
		[Test]
		public void Returns_false_if_weight_is_very_different() {
			var result = _coinWeightCheck.CheckCoin(new CoinInput {Mass = 1}, new CoinInput {Mass = 12});
			Assert.That(result, Is.False);
		}

		[Test]
		public void Returns_true_if_weight_is_the_same() {
			var result = _coinWeightCheck.CheckCoin(new CoinInput { Mass = 1 }, new CoinInput { Mass = 1 });
			Assert.That(result, Is.True);
		}

		[Test]
		public void Returns_true_if_weight_is_less_than_one_percent_more() {
			var result = _coinWeightCheck.CheckCoin(new CoinInput { Mass = 1.001 }, new CoinInput { Mass = 1 });
			Assert.That(result, Is.True);
		}

		[Test]
		public void Returns_true_if_weight_is_less_than_one_percent_less() {
			var result = _coinWeightCheck.CheckCoin(new CoinInput { Mass = 0.999 }, new CoinInput { Mass = 1 });
			Assert.That(result, Is.True);
		}
	}
}
