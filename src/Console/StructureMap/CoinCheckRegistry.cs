using Console.CoinChecks;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
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