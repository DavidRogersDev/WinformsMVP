using SampleApp.Services;
using StructureMap.Configuration.DSL;

namespace SampleApp.Ioc
{
	public class DependancyRegistry : Registry
	{
		public DependancyRegistry()
		{
			For<ITimeTrackerService>().Add<TimeTrackerService>();
		}
	}
}
