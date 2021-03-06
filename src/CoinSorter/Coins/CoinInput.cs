namespace CoinSorter.Coins
{
	public class CoinInput
	{
		public double Diameter { get; set; }
		public double Mass { get; set; }

		public static CoinInput OnePenny() {
			return new CoinInput {Mass = 3.56, Diameter = 20.32};
		}

		public static CoinInput TwoPence() {
			return new CoinInput {Mass = 7.12, Diameter = 25.9};
		}

		public static CoinInput FivePence() {
			return new CoinInput {Mass = 3.25, Diameter = 18};
		}

		public static CoinInput TenPence() {
			return new CoinInput {Mass = 6.5, Diameter = 24.5};
		}

		public static CoinInput TwentyPence() {
			return new CoinInput {Mass = 5, Diameter = 22.5};
		}

		public static CoinInput FiftyPence() {
			return new CoinInput {Mass = 8, Diameter = 27.3};
		}
	}
}