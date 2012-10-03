
using StructureMap;

namespace ExampleApplication.Ioc
{
    public static class ServiceLocator
    {
        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
