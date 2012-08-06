using StructureMap;

namespace SampleApp.Ioc
{
    public static class ServiceLocator
    {
        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
