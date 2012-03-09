using CoinSorter;
using CoinSorter.Coins;
using CoinSorter.StructureMap;
using NUnit.Framework;
using StructureMap;

namespace Acceptance.Tests {
	[TestFixture]
	public class Tests {
		private IContainer _container;
		private ISorter _sorter;

		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			_container = DependencyResolver.Container;
			_sorter = _container.GetInstance<ISorter>();
		}

		[Test]
		public void Correctly_identifies_fifty_pence() {
			var result = _sorter.Sort(CoinInput.FiftyPence());

			Assert.That(result.Value, Is.EqualTo("50p"));
		}

		[Test]
		public void Correctly_identifies_slighty_worn_fifty_pence() {
			var coin = CoinInput.FiftyPence();
			coin.Mass = coin.Mass*0.999;

			var result = _sorter.Sort(coin);

			Assert.That(result.Value, Is.EqualTo("50p"));
		}

		[Test]
		public void Correctly_idenfies_fake_coin() {
			var coin = CoinInput.FiftyPence();
			coin.Mass = 1000;

			var result = _sorter.Sort(coin);

			Assert.That(result.Value, Is.EqualTo("fake"));
		}
	}
}
