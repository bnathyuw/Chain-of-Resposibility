using CoinSorter.Coins;

namespace CoinSorter.CoinIdentifiers
{
	public interface ICoinIdentifier
	{
		ICoin Identify(CoinInput coinInput);
	}
}