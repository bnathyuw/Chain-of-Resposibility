using CoinSorter;
using CoinSorter.Coins;
using CoinSorter.StructureMap;
using NUnit.Framework;
using StructureMap;

namespace Acceptance.Tests {
	[TestFixture]
	public class Tests {
		private IContainer _container;
		private ICoinSorter _coinSorter;

		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			_container = DependencyResolver.Container;
			_coinSorter = _container.GetInstance<ICoinSorter>();
		}

		[Test]
		public void Correctly_identifies_fifty_pence() {
			var result = _coinSorter.Sort(CoinInput.FiftyPence());

			Assert.That(result.Value, Is.EqualTo("50p"));
		}

		[Test]
		public void Correctly_identifies_slighty_worn_fifty_pence() {
			var coin = CoinInput.FiftyPence();
			coin.Mass = coin.Mass*0.999;

			var result = _coinSorter.Sort(coin);

			Assert.That(result.Value, Is.EqualTo("50p"));
		}

		[Test]
		public void Correctly_idenfies_fake_coin() {
			var coin = CoinInput.FiftyPence();
			coin.Mass = 1000;

			var result = _coinSorter.Sort(coin);

			Assert.That(result.Value, Is.EqualTo("fake"));
		}
	}
}
