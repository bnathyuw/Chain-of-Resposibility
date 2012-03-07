namespace Console.CoinIdentifiers
{
	internal interface ICoinIdentifier
	{
		ICoin Identify(CoinInput coinInput);
	}
}