using System;

namespace Console.CoinIdentifiers
{
	internal class FivePenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 3.25;
		private const string COIN_VALUE = "5p";
		private readonly ICoinIdentifier _successor;

		public FivePenceIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS) / EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}