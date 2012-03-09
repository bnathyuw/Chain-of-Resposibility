using System;
using CoinSorter.Coins;

namespace CoinSorter.CoinChecks
{
	public class CoinMassCheck : ICoinCheck
	{
		private readonly ICoinCheck _successor;

		public CoinMassCheck(ICoinCheck successor) {
			_successor = successor;
		}

		public bool CheckCoin(CoinInput coinInput, CoinInput coinSpec) {
			return Math.Abs((coinInput.Mass - coinSpec.Mass)/coinSpec.Mass) < 0.01 && _successor.CheckCoin(coinInput, coinSpec);
		}
	}
}