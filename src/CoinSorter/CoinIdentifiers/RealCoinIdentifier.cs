using CoinSorter.CoinChecks;
using CoinSorter.Coins;

namespace CoinSorter.CoinIdentifiers
{
	public class RealCoinIdentifier : ICoinIdentifier
	{
		private readonly string _value;
		private readonly CoinInput _coinSpec;
		private readonly ICoinIdentifier _successor;
		private readonly ICoinCheck _coinCheck;

		public RealCoinIdentifier(ICoinIdentifier successor, ICoinCheck coinCheck, CoinInput coinSpec, string value) {
			_coinSpec = coinSpec;
			_successor = successor;
			_coinCheck = coinCheck;
			
			_value = value;
		}

		public Coin Identify(CoinInput coinInput) {
			return _coinCheck.CheckCoin(coinInput, _coinSpec) 
				? new Coin { Value = _value }
				: _successor.Identify(coinInput);
		}
	}
}