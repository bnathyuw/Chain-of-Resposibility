using CoinSorter.Coins;

namespace CoinSorter
{
	public interface ISorter
	{
		Coin Sort(CoinInput coinInput);
	}
}