namespace Console.CoinChecks
{
	public class PassCoinCheck:ICoinCheck
	{
		public bool CheckCoin(CoinInput coinInput, CoinInput coinSpec) {
			return true;
		}
	}
}