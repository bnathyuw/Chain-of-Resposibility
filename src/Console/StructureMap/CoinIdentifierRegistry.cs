using Console.CoinIdentifiers;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinIdentifierRegistry:Registry
	{
		public CoinIdentifierRegistry() {
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("FiftyPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwentyPence"))
				.Ctor<double>("expectedMass").Is(8)
				.Ctor<string>("value").Is("50p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TwentyPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TenPence"))
				.Ctor<double>("expectedMass").Is(5)
				.Ctor<string>("value").Is("20p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TenPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("FivePence"))
				.Ctor<double>("expectedMass").Is(6.5)
				.Ctor<string>("value").Is("10p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("FivePence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwoPence"))
				.Ctor<double>("expectedMass").Is(3.25)
				.Ctor<string>("value").Is("5p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TwoPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("OnePenny"))
				.Ctor<double>("expectedMass").Is(7.12)
				.Ctor<string>("value").Is("2p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("OnePenny")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("Fake"))
				.Ctor<double>("expectedMass").Is(3.56)
				.Ctor<string>("value").Is("1p");
			For<ICoinIdentifier>().Add<FakeCoinIdentifier>().Named("Fake");
		}
	}
}