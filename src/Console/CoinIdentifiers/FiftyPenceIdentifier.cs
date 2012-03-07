using System;

namespace Console.CoinIdentifiers
{
	internal class FiftyPenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 8;
		private const string COIN_VALUE = "50p";
		private readonly ICoinIdentifier _successor;

		public FiftyPenceIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS)/EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}