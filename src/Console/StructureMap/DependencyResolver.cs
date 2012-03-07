using Console.CoinIdentifiers;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Console.StructureMap
{
	static public class DependencyResolver {
		public static IContainer Container {
			get {
				ObjectFactory.Configure(Configure);
				var container = ObjectFactory.Container;
				return container;
			}
		}

		private static void Configure(ConfigurationExpression x) {
			x.AddRegistry<CoinSorterRegistry>();
			x.AddRegistry<CoinIdentifierRegistry>();
			
		}
	}

	internal class CoinSorterRegistry:Registry
	{
		public CoinSorterRegistry() {
			For<ICoinSorter>().Use<CoinSorter>().Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("FiftyPence"));
		}
	}

	internal class CoinIdentifierRegistry:Registry
	{
		public CoinIdentifierRegistry() {
			For<ICoinIdentifier>().Add<FiftyPenceIdentifier>().Named("FiftyPence").Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("TwentyPence"));
			For<ICoinIdentifier>().Add<TwentyPenceIdentifier>().Named("TwentyPence").Ctor<ICoinIdentifier>().Is(x => x.GetInstance<ICoinIdentifier>("Fake"));
			For<ICoinIdentifier>().Add<FakeCoinIdentifier>().Named("Fake");
		}
	}
}