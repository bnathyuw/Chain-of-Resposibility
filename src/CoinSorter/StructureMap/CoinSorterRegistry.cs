using CoinSorter.CoinIdentifiers;
using StructureMap.Configuration.DSL;

namespace CoinSorter.StructureMap
{
	internal class CoinSorterRegistry:Registry
	{
		public CoinSorterRegistry() {
			For<ICoinSorter>().Use<CoinSorter>().Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>());
		}
	}
}