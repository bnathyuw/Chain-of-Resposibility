using Console.Coins;

namespace Console.CoinSorter
{
	public interface ICoinSorter
	{
		ICoin Sort(CoinInput coinInput);
	}
}