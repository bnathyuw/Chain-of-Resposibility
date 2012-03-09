using Console.Coins;

namespace Console.CoinIdentifiers
{
	public interface ICoinIdentifier
	{
		ICoin Identify(CoinInput coinInput);
	}
}