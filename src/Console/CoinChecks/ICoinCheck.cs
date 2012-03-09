using Console.Coins;

namespace Console.CoinChecks
{
	public interface ICoinCheck
	{
		bool CheckCoin(CoinInput coinInput, CoinInput coinSpec);
	}
}