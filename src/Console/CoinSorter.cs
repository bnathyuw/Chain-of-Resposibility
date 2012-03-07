using Console.CoinIdentifiers;

namespace Console
{
	internal class CoinSorter : ICoinSorter
	{
		private readonly ICoinIdentifier _coinIdentifier;

		public CoinSorter(ICoinIdentifier coinIdentifier) {
			_coinIdentifier = coinIdentifier;
		}

		public ICoin Sort(CoinInput coinInput) {
			return _coinIdentifier.Identify(coinInput);
		}
	}
}