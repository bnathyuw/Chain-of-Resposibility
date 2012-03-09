using System;
using CoinSorter;
using CoinSorter.Coins;
using CoinSorter.StructureMap;
using StructureMap;
using Con = System.Console;

namespace Console
{
	internal static class Program
	{
		private static readonly ISorter _sorter;

		static Program() {
			IContainer container = DependencyResolver.Container;
			_sorter = container.GetInstance<ISorter>();
		}

		private static void Main() {
			while (true) {
				double mass = ReadCoinMass();
				double diameter = ReadCoinDiameter();
				var coinInput = new CoinInput {Mass = mass, Diameter = diameter};

				Coin coin = _sorter.Sort(coinInput);

				Con.WriteLine("You have entered a {0} coin", coin.Value);

				if (!ReadContinue()) {
					return;
				}
				Con.WriteLine();
			}
		}

		private static double ReadCoinDiameter() {
			Con.WriteLine("Enter coin diameter");
			string diameterString = Con.ReadLine();
			double diameter;
			while (!double.TryParse(diameterString, out diameter)) {
				Con.WriteLine("Say that again?");
				diameterString = Con.ReadLine();
			}
			return diameter;
		}

		private static bool ReadContinue() {
			Con.WriteLine("Play again? y/n");
			ConsoleKeyInfo key = Con.ReadKey();
			while (key.KeyChar != 'y' && key.KeyChar != 'n') {
				Con.WriteLine("Say that again?");
				key = Con.ReadKey();
			}
			return key.KeyChar == 'y';
		}

		private static double ReadCoinMass() {
			Con.WriteLine("Enter coin mass");
			string massString = Con.ReadLine();
			double mass;
			while (!double.TryParse(massString, out mass)) {
				Con.WriteLine("Say that again?");
				massString = Con.ReadLine();
			}
			return mass;
		}
	}
}