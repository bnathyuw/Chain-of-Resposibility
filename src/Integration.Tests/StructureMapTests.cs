using Console;
using Console.StructureMap;
using NUnit.Framework;

namespace Integration.Tests
{
	[TestFixture]
	public class StructureMapTests
	{
		[Test]
		public void ConfigurationIsValid() {
			var container = DependencyResolver.Container;
			container.AssertConfigurationIsValid();
		}
	}
}