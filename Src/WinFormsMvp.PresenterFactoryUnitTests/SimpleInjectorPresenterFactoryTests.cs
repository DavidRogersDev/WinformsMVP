using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using WinFormsMvp.Binder;
using WinFormsMvp.SimpleInjector;

namespace WinFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class SimpleInjectorPresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var container = new Container();
            return new SimpleInjectorPresenterFactory(container);
        }
    }
}
