using Console.CoinChecks;

namespace Console.CoinIdentifiers
{
	internal class RealCoinIdentifier : ICoinIdentifier
	{
		private readonly double _expectedMass;
		private readonly string _value;
		private readonly ICoinIdentifier _successor;
		private readonly ICoinCheck _coinCheck;

		public RealCoinIdentifier(ICoinIdentifier successor, ICoinCheck coinCheck, double expectedMass, string value) {
			_successor = successor;
			_coinCheck = coinCheck;
			_expectedMass = expectedMass;
			_value = value;
		}

		public ICoin Identify(CoinInput coinInput) {
			return _coinCheck.CheckCoin(coinInput, new CoinInput{Mass = _expectedMass}) 
				? new Coin { Value = _value }
				: _successor.Identify(coinInput);
		}
	}
}