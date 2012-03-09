using CoinSorter.Coins;

namespace CoinSorter
{
	public interface ICoinSorter
	{
		ICoin Sort(CoinInput coinInput);
	}
}