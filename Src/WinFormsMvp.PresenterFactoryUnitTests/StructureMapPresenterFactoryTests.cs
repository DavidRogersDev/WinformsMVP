using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using WinFormsMvp.Binder;
using WinFormsMvp.StructureMap;

namespace WinFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class StructureMapPresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var container = new Container();
            return new StructureMapPresenterFactory(container);
        }
    }
}
