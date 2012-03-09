using Console.CoinIdentifiers;
using Console.CoinSorter;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinSorterRegistry:Registry
	{
		public CoinSorterRegistry() {
			For<ICoinSorter>().Use<CoinSorter.CoinSorter>().Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>());
		}
	}
}