using ExampleApplication.Services;
using StructureMap.Configuration.DSL;

namespace ExampleApplication.Ioc
{
	public class DependancyRegistry : Registry
	{
		public DependancyRegistry()
		{
			For<ITimeTrackerService>().Singleton().Add<TimeTrackerService>();
		}
	}
}
