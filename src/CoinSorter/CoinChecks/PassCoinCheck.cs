using CoinSorter.Coins;

namespace CoinSorter.CoinChecks
{
	public class PassCoinCheck:ICoinCheck
	{
		public bool CheckCoin(CoinInput coinInput, CoinInput coinSpec) {
			return true;
		}
	}
}