using CoinSorter;
using CoinSorter.Coins;
using CoinSorter.StructureMap;
using Con = System.Console;

namespace Console
{
	internal static class Program
	{
		private static readonly ICoinSorter _coinSorter;

		static Program() {
			var container = DependencyResolver.Container;
			_coinSorter = container.GetInstance<ICoinSorter>();
		}

		private static void Main() {
			while (true) {
				var mass = ReadCoinMass();
				var diameter = ReadCoinDiameter();
				var coinInput = new CoinInput {Mass = mass, Diameter = diameter};

				var coin = _coinSorter.Sort(coinInput);

				Con.WriteLine("You have entered a {0} coin", coin.Value);

				if (!ReadContinue()) return;
				Con.WriteLine();
			}
		}

		private static double ReadCoinDiameter() {
			Con.WriteLine("Enter coin diameter");
			var diameterString = Con.ReadLine();
			double diameter;
			while (!double.TryParse(diameterString, out diameter)) {
				Con.WriteLine("Say that again?");
				diameterString = Con.ReadLine();
			}
			return diameter;
		}

		private static bool ReadContinue() {
			Con.WriteLine("Play again? y/n");
			var key = Con.ReadKey();
			while (key.KeyChar != 'y' && key.KeyChar != 'n') {
				Con.WriteLine("Say that again?");
				key = Con.ReadKey();
			}
			return key.KeyChar == 'y';
		}

		private static double ReadCoinMass() {
			Con.WriteLine("Enter coin mass");
			var massString = Con.ReadLine();
			double mass;
			while (!double.TryParse(massString, out mass)) {
				Con.WriteLine("Say that again?");
				massString = Con.ReadLine();
			}
			return mass;
		}
	}
}