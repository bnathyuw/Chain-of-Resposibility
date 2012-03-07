using Console.CoinIdentifiers;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinIdentifierRegistry:Registry
	{
		public CoinIdentifierRegistry() {
			For<ICoinIdentifier>().Add<FiftyPenceIdentifier>().Named("FiftyPence").Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwentyPence"));
			For<ICoinIdentifier>().Add<TwentyPenceIdentifier>().Named("TwentyPence").Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("Fake"));
			For<ICoinIdentifier>().Add<FakeCoinIdentifier>().Named("Fake");
		}
	}
}