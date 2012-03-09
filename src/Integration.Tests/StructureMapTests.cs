using CoinSorter.StructureMap;
using NUnit.Framework;
using StructureMap;

namespace Integration.Tests
{
	[TestFixture]
	public class StructureMapTests
	{
		[Test]
		public void ConfigurationIsValid() {
			IContainer container = DependencyResolver.Container;
			container.AssertConfigurationIsValid();
		}
	}
}