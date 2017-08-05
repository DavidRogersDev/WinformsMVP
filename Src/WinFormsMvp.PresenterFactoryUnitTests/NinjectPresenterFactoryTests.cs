using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using WinFormsMvp.Binder;
using WinFormsMvp.Ninject;

namespace WinFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class NinjectPresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var kernel = new StandardKernel();
            return new NinjectPresenterFactory(kernel);
        }
    }
}
