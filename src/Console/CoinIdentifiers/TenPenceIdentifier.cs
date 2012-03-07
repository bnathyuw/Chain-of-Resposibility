using System;

namespace Console.CoinIdentifiers
{
	internal class TenPenceIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 6.5;
		private const string COIN_VALUE = "10p";
		private readonly ICoinIdentifier _successor;

		public TenPenceIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS) / EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}