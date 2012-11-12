using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WinFormsMvp.Binder
{
    /// <summary>
    /// Combines multiple presenter discovery strategies into one. Strategies will be evaluated in the order
    /// they are provided. The first strategy to provide a result wins.
    /// </summary>
    public class CompositePresenterDiscoveryStrategy : IPresenterDiscoveryStrategy
    {
        readonly IEnumerable<IPresenterDiscoveryStrategy> strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositePresenterDiscoveryStrategy"/> class.
        /// </summary>
        /// <param name="strategies">The strategies to be evaluated.</param>
        public CompositePresenterDiscoveryStrategy(params IPresenterDiscoveryStrategy[] strategies)
            : this((IEnumerable<IPresenterDiscoveryStrategy>)strategies)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositePresenterDiscoveryStrategy"/> class.
        /// </summary>
        /// <param name="strategies">The strategies to be evaluated.</param>
        public CompositePresenterDiscoveryStrategy(IEnumerable<IPresenterDiscoveryStrategy> strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException("strategies");

            // Force the strategies to be enumerated once, just in case somebody gave us an expensive
            // and uncached list.
            this.strategies = strategies.ToArray();

            if (!strategies.Any())
                throw new ArgumentException("You must supply at least one strategy.", "strategies");
        }

        /// <summary>
        /// Gets the presenter bindings for passed view.
        /// </summary>
        /// <param name="viewInstance">The view instances (user controls, forms, etc).</param>
        public PresenterDiscoveryResult GetBinding(IView viewInstance)
        {
            if (ReferenceEquals(viewInstance, null))
                throw new ArgumentNullException("viewInstance");

            var results = new List<PresenterDiscoveryResult>();

            foreach (var strategy in strategies)
            {
                var resultsThisRound = strategy.GetBinding(viewInstance);

                if (ReferenceEquals(resultsThisRound, null))
                    continue;

                results.Add(resultsThisRound);
            }

            return results.GroupBy(r => r.ViewInstances).Select(r => BuildMergedResult(r.Key, r)).First(); 
        }

        static PresenterDiscoveryResult BuildMergedResult(IEnumerable<IView> viewInstances, IEnumerable<PresenterDiscoveryResult> results)
        {
            return new PresenterDiscoveryResult
            (
                viewInstances,
                string.Format(
                    CultureInfo.InvariantCulture,
                    "CompositePresenterDiscoveryStrategy:\r\n\r\n{0}",
                    string.Join("\r\n\r\n", results.Select(r => r.Message).ToArray())
                ),
                results.SelectMany(r => r.Bindings)
            );
        }
    }
}