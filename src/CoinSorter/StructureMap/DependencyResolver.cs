using StructureMap;

namespace CoinSorter.StructureMap
{
	public static class DependencyResolver
	{
		public static IContainer Container {
			get {
				ObjectFactory.Configure(Configure);
				IContainer container = ObjectFactory.Container;
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