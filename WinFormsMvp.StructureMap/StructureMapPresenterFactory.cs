/*
 *   This class is taken from the webformsmvpcontrib project https://webformsmvpcontrib.codeplex.com/ .
 *   All copyright is owned by that project and it is used here under the MIT licence.
 */

using System;
using StructureMap;
using StructureMap.Pipeline;
using WinFormsMvp.Binder;

namespace WinFormsMvp.StructureMap
{
    public class StructureMapPresenterFactory : IPresenterFactory
    {
        readonly IContainer container;
        readonly object registerLock = new object();

        public StructureMapPresenterFactory(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            if (presenterType == null)
                throw new ArgumentNullException("presenterType");
            if (viewType == null)
                throw new ArgumentNullException("viewType");
            if (viewInstance == null)
                throw new ArgumentNullException("viewInstance");

            if (!container.Model.HasImplementationsFor(presenterType))
            {
                lock (registerLock)
                {
                    if (!container.Model.HasImplementationsFor(presenterType))
                    {
                        container.Configure(x => x.For(presenterType).HybridHttpOrThreadLocalScoped().Use(presenterType).Named(presenterType.Name));
                    }
                }
            }

            var args = new ExplicitArguments();
            args.Set("view");
            args.SetArg("view", viewInstance);

            return (IPresenter)container.GetInstance(presenterType, args);
        }

        public void Release(IPresenter presenter)
        {
            container.EjectAllInstancesOf<IPresenter>();

            var disposablePresenter = presenter as IDisposable;
            if (disposablePresenter != null)
                disposablePresenter.Dispose();
        }
    }
}
