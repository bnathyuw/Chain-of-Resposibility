using System;

namespace Console.CoinIdentifiers
{
	internal class TwentyPenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 5;
		private const string COIN_VALUE = "20p";
		private readonly ICoinIdentifier _successor;

		public TwentyPenceIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS) / EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}