using StructureMap;

namespace CoinSorter.StructureMap
{
	public static class DependencyResolver
	{
		public static IContainer Container {
			get {
				ObjectFactory.Configure(Configure);
				return ObjectFactory.Container;
			}
		}

		private static void Configure(ConfigurationExpression x) {
			x.AddRegistry<CoinSorterRegistry>();
			x.AddRegistry<CoinIdentifierRegistry>();
			x.AddRegistry<CoinCheckRegistry>();
		}
	}
}