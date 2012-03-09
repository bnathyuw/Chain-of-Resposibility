using CoinSorter.CoinIdentifiers;
using CoinSorter.Coins;

namespace CoinSorter
{
	public class Sorter : ISorter
	{
		private readonly ICoinIdentifier _coinIdentifier;

		public Sorter(ICoinIdentifier coinIdentifier) {
			_coinIdentifier = coinIdentifier;
		}

		public Coin Sort(CoinInput coinInput) {
			return _coinIdentifier.Identify(coinInput);
		}
	}
}