using SampleApp.Services;
using StructureMap.Configuration.DSL;
using SampleApp.Views;

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
