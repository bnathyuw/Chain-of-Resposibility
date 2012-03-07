using System;

namespace Console.CoinChecks
{
	public interface ICoinCheck
	{
		bool CheckCoin(CoinInput coinInput, CoinInput coinSpec);
	}

	public class CoinWeightCheck : ICoinCheck {
		public bool CheckCoin(CoinInput coinInput, CoinInput coinSpec) {
			return Math.Abs((coinInput.Mass - coinSpec.Mass)/coinSpec.Mass) < 0.01;
		}
	}
}