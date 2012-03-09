using StructureMap;

namespace CoinSorter.StructureMap
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
			x.AddRegistry<CoinCheckRegistry>();
		}
	}
}