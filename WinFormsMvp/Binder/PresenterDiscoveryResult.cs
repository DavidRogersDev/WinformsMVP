using System;
using System.Collections.Generic;

namespace WinFormsMvp.Binder
{
    /// <summary />
    public class PresenterDiscoveryResult
    {
        readonly IEnumerable<IView> viewInstances;
        readonly string message;
        readonly IEnumerable<PresenterBinding> bindings;

        /// <summary />
        public PresenterDiscoveryResult(IEnumerable<IView> viewInstances, string message, IEnumerable<PresenterBinding> bindings)
        {
            this.viewInstances = viewInstances;
            this.message = message;
            this.bindings = bindings;
        }

        /// <summary />
        public IEnumerable<IView> ViewInstances { get { return viewInstances; } }

        /// <summary />
        public string Message { get { return message; } }

        /// <summary />
        public IEnumerable<PresenterBinding> Bindings { get { return bindings; } }

        /// <summary>
        /// Determines whether the specified <see cref="PresenterDiscoveryResult"/> is equal to the current <see cref="PresenterDiscoveryResult"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="PresenterDiscoveryResult"/> is equal to the current <see cref="PresenterDiscoveryResult"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="PresenterDiscoveryResult"/> to compare with the current <see cref="PresenterDiscoveryResult"/>.</param>
        public override bool Equals(object obj)
        {
            var target = obj as PresenterDiscoveryResult;
            if (target == null) return false;

            return
                ViewInstances.SetEqual(target.ViewInstances) &&
                Message.Equals(target.Message, StringComparison.OrdinalIgnoreCase) &&
                Bindings.SetEqual(target.Bindings);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="PresenterDiscoveryResult"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return
                ViewInstances.GetHashCode() |
                Message.GetHashCode() |
                Bindings.GetHashCode();
        }
    }
}