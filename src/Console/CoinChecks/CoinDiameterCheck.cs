using System;

namespace Console.CoinChecks
{
	public class CoinDiameterCheck:ICoinCheck
	{
		private readonly ICoinCheck _successor;
		public CoinDiameterCheck(ICoinCheck successor) {
			_successor = successor;
		}

		public bool CheckCoin(CoinInput coinInput, CoinInput coinSpec) {
			return Math.Abs(coinInput.Diameter - coinSpec.Diameter) < 0.0001 && _successor.CheckCoin(coinInput, coinSpec);
		}
	}
}