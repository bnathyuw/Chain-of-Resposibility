using Console.CoinIdentifiers;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinSorterRegistry:Registry
	{
		public CoinSorterRegistry() {
			For<ICoinSorter>().Use<CoinSorter>().Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>());
		}
	}
}