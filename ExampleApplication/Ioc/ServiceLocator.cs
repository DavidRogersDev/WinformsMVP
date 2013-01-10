
using ExampleApplication.Services;
using StructureMap;

namespace ExampleApplication.Ioc
{
    public static class ServiceLocator
    {
        private static ITimeTrackerService timeTrackerService;

        //  This is messy and not nice. But it'll suffice for a sample app.
        public static T Resolve<T>()
        {
            if (typeof(T) == typeof(ITimeTrackerService))
            {
                if (timeTrackerService == null)
                {
                    timeTrackerService = ObjectFactory.GetInstance<ITimeTrackerService>();
                    return (T)timeTrackerService;
                }
                else
                {
                    return (T)timeTrackerService;
                }
            }
            else
            {
                return ObjectFactory.GetInstance<T>();
            }
        }
    }
}
