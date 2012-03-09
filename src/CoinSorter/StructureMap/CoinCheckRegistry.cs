using CoinSorter.CoinChecks;
using StructureMap.Configuration.DSL;

namespace CoinSorter.StructureMap
{
	internal class CoinCheckRegistry:Registry
	{
		public CoinCheckRegistry() {
			For<ICoinCheck>().Use<CoinMassCheck>()
				.Ctor<ICoinCheck>("successor").Is(x => x.GetInstance<ICoinCheck>("Diameter"));
			For<ICoinCheck>().Add<CoinDiameterCheck>().Named("Diameter")
				.Ctor<ICoinCheck>("successor").Is(x => x.GetInstance<ICoinCheck>("Pass"));
			For<ICoinCheck>().Add<PassCoinCheck>().Named("Pass");
		}
	}
}