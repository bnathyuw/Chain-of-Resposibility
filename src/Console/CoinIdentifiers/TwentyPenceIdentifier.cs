using System;
using Console.CoinChecks;

namespace Console.CoinIdentifiers
{
	internal class TwentyPenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 5;
		private const string COIN_VALUE = "20p";
		private readonly ICoinIdentifier _successor;
		private readonly ICoinCheck _coinCheck;

		public TwentyPenceIdentifier(ICoinIdentifier successor, ICoinCheck coinCheck) {
			_successor = successor;
			_coinCheck = coinCheck;
		}

		public ICoin Identify(CoinInput coinInput) {
			return _coinCheck.CheckCoin(coinInput, new CoinInput{Mass = EXPECTED_MASS}) 
				? new Coin { Value = COIN_VALUE }
				: _successor.Identify(coinInput);
		}
	}
}