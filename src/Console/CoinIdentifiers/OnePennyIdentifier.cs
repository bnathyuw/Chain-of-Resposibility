using System;

namespace Console.CoinIdentifiers
{
	internal class OnePennyIdentifier : ICoinIdentifier
	{
		private const double EXPECTED_MASS = 3.56;
		private const string COIN_VALUE = "1p";
		private readonly ICoinIdentifier _successor;

		public OnePennyIdentifier(ICoinIdentifier successor) {
			_successor = successor;
		}

		public ICoin Identify(CoinInput coinInput) {
			return Math.Abs((coinInput.Mass - EXPECTED_MASS) / EXPECTED_MASS) < 0.01 ? new Coin { Value = COIN_VALUE } : _successor.Identify(coinInput);
		}
	}
}