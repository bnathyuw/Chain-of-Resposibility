using CoinSorter.Coins;

namespace CoinSorter
{
	public interface ISorter
	{
		ICoin Sort(CoinInput coinInput);
	}
}