using CoinSorter.Coins;

namespace CoinSorter.CoinIdentifiers
{
	public interface ICoinIdentifier
	{
		Coin Identify(CoinInput coinInput);
	}
}