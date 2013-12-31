using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsMvp.Binder;
using WinFormsMvp.Unity;

namespace WinFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class UnityPresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var container = new UnityContainer();
            return new UnityPresenterFactory(container);
        }
    }
}
