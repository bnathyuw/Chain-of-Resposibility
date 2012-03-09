using CoinSorter.Coins;

namespace CoinSorter.CoinSorter
{
	public interface ICoinSorter
	{
		ICoin Sort(CoinInput coinInput);
	}
}