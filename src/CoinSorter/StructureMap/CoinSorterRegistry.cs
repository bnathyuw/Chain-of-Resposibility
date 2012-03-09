using CoinSorter.CoinIdentifiers;
using CoinSorter.CoinSorter;
using StructureMap.Configuration.DSL;

namespace CoinSorter.StructureMap
{
	internal class CoinSorterRegistry:Registry
	{
		public CoinSorterRegistry() {
			For<ICoinSorter>().Use<CoinSorter.CoinSorter>().Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>());
		}
	}
}