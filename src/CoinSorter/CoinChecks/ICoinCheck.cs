using CoinSorter.Coins;

namespace CoinSorter.CoinChecks
{
	public interface ICoinCheck
	{
		bool CheckCoin(CoinInput coinInput, CoinInput coinSpec);
	}
}