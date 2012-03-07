namespace Console.CoinIdentifiers
{
	internal class FakeCoinIdentifier:ICoinIdentifier
	{
		public ICoin Identify(CoinInput coinInput) {
			return new Coin {Value = "fake"};
		}
	}
}