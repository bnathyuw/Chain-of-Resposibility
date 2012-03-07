using Console.CoinChecks;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinCheckRegistry:Registry
	{
		public CoinCheckRegistry() {
			For<ICoinCheck>().Use<CoinWeightCheck>();
		}
	}
}