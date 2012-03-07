using System;

namespace Console.CoinIdentifiers
{
	internal class TwoPenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 7.12;
		private const string COIN_VALUE = "2p";
		private readonly ICoinIdentifier _successor;

		public TwoPenceIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS) / EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}