using Console.CoinIdentifiers;
using Console.Coins;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	internal class CoinIdentifierRegistry:Registry
	{
		public CoinIdentifierRegistry() {
			For<ICoinIdentifier>().Use<RealCoinIdentifier>()
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwentyPence"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.FiftyPence())
				.Ctor<string>("value").Is("50p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TwentyPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TenPence"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.TwentyPence())
				.Ctor<string>("value").Is("20p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TenPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("FivePence"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.TenPence())
				.Ctor<string>("value").Is("10p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("FivePence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwoPence"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.FivePence())
				.Ctor<string>("value").Is("5p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("TwoPence")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("OnePenny"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.TwoPence())
				.Ctor<string>("value").Is("2p");
			For<ICoinIdentifier>().Add<RealCoinIdentifier>().Named("OnePenny")
				.Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("Fake"))
				.Ctor<CoinInput>("coinSpec").Is(CoinInput.OnePenny())
				.Ctor<string>("value").Is("1p");
			For<ICoinIdentifier>().Add<FakeCoinIdentifier>().Named("Fake");
		}
	}
}