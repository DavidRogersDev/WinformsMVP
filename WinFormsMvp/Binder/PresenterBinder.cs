using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WinFormsMvp.Binder
{
    /// <summary/>
    public sealed class PresenterBinder
    {
        static IPresenterFactory factory;
        ///<summary>
        /// Gets or sets the factory that the binder will use to create
        /// new presenter instances. This is pre-initialized to a
        /// default implementation but can be overriden if desired.
        /// This property can only be set once.
        ///</summary>
        ///<exception cref="ArgumentNullException">Thrown if a null value is passed to the setter.</exception>
        ///<exception cref="InvalidOperationException">Thrown if the property is being set for a second time.</exception>
        public static IPresenterFactory Factory
        {
            get
            {
                return factory ?? (factory = new DefaultPresenterFactory());
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (factory != null)
                {
                    throw new InvalidOperationException(
                        factory is DefaultPresenterFactory
                        ? "The factory has already been set, and can be not changed at a later time. In this case, it has been set to the default implementation. This happens if the factory is used before being explicitly set. If you wanted to supply your own factory, you need to do this in your Application_Start event."
                        : "You can only set your factory once, and should really do this in Application_Start.");
                }
                factory = value;
            }
        }

        static IPresenterDiscoveryStrategy discoveryStrategy;
        ///<summary>
        /// Gets or sets the strategy that the binder will use to discover which presenters should be bound to which views.
        /// This is pre-initialized to a default implementation but can be overriden if desired. To combine multiple
        /// strategies in a fallthrough approach, use <see cref="CompositePresenterDiscoveryStrategy"/>.
        ///</summary>
        ///<exception cref="ArgumentNullException">Thrown if a null value is passed to the setter.</exception>
        public static IPresenterDiscoveryStrategy DiscoveryStrategy
        {
            get
            {
                //return discoveryStrategy ?? (discoveryStrategy = new AttributeBasedPresenterDiscoveryStrategy());
                return discoveryStrategy ?? (discoveryStrategy = new CompositePresenterDiscoveryStrategy(
                    new AttributeBasedPresenterDiscoveryStrategy(),
                    new ConventionBasedPresenterDiscoveryStrategy()
                    ));
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                discoveryStrategy = value;
            }
        }

        /// <summary>
        /// Occurs when the binder creates a new presenter instance. Useful for
        /// populating extra information into presenters.
        /// </summary>
        public event EventHandler<PresenterCreatedEventArgs> PresenterCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresenterBinder"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="httpContext">The owning HTTP context.</param>
        public PresenterBinder()
        {
            
        }

        /// <summary>
        /// Attempts to bind any already registered views.
        /// </summary>
        public void PerformBinding(IView viewInstance)
        {
            try
            {
                PerformBinding(
                    viewInstance,
                    DiscoveryStrategy,
                    p => OnPresenterCreated(new PresenterCreatedEventArgs(p)),
                    Factory);

            }
            catch (Exception e)
            {

            }
        }

        private void OnPresenterCreated(PresenterCreatedEventArgs args)
        {
            if (PresenterCreated != null)
            {
                PresenterCreated(this, args);
            }
        }

        static IPresenter PerformBinding(
            IView candidate,
            IPresenterDiscoveryStrategy presenterDiscoveryStrategy,
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory)
        {
            var bindings = GetBindings(
                candidate,
                presenterDiscoveryStrategy);

            var newPresenter = BuildPresenter(
                presenterCreatedCallback,
                presenterFactory,
                new[] {bindings});

            return newPresenter;
        }

        static PresenterBinding GetBindings(IView candidate, IPresenterDiscoveryStrategy presenterDiscoveryStrategy)
        {
            var result = presenterDiscoveryStrategy.GetBinding(candidate);

            ThrowExceptionsForViewsWithNoPresenterBound(result);

            return  result.Bindings.Single();
        }

        static void ThrowExceptionsForViewsWithNoPresenterBound(PresenterDiscoveryResult result)
        {
            if(result.Bindings.Empty() && result.ViewInstances.Where(v => v.ThrowExceptionIfNoPresenterBound).Any())

            throw new InvalidOperationException(string.Format(
                CultureInfo.InvariantCulture,
                @"Failed to find presenter for view instance of {0}.{1} If you do not want this exception to be thrown, set ThrowExceptionIfNoPresenterBound to false on your view.",
                result.ViewInstances.Where(v => v.ThrowExceptionIfNoPresenterBound).Single().GetType().FullName,
                result.Message
            ));
        }

        static IPresenter BuildPresenter(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            IEnumerable<PresenterBinding> bindings)
        {
            return bindings
                .Select(binding =>
                    BuildPresenters(
                        presenterCreatedCallback,
                        presenterFactory,
                        binding)).ToList().First();
        }

        static IPresenter BuildPresenters(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            PresenterBinding binding)
        {
            IView viewToCreateFor = binding.ViewInstance; 

            return BuildPresenter(
                    presenterCreatedCallback,
                    presenterFactory,
                    binding,
                    viewToCreateFor);
        }

        static IPresenter BuildPresenter(
            Action<IPresenter> presenterCreatedCallback,
            IPresenterFactory presenterFactory,
            PresenterBinding binding,
            IView viewInstance)
        {

            var presenter = presenterFactory.Create(binding.PresenterType, binding.ViewType, viewInstance);
            if (presenterCreatedCallback != null)
            {
                presenterCreatedCallback(presenter);
            }
            return presenter;
        }

    }
}