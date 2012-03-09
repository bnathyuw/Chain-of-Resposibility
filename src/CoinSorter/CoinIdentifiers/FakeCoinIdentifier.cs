using CoinSorter.Coins;

namespace CoinSorter.CoinIdentifiers
{
	public class FakeCoinIdentifier:ICoinIdentifier
	{
		public Coin Identify(CoinInput coinInput) {
			return new Coin {Value = "fake"};
		}
	}
}