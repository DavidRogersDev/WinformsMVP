using System;
using System.Collections.Generic;
using System.Globalization;

namespace WinFormsMvp
{
    ///<summary>
    /// Provides a basic implementation of the <see cref="ICompositeView"/> contract.
    ///</summary>
    public abstract class CompositeView<TView> : ICompositeView
        where TView : class, IView
    {
        readonly ICollection<TView> views = new List<TView>();

        /// <summary>
        /// Gets the list of individual views represented by this composite view.
        /// </summary>
        protected internal IEnumerable<TView> Views
        {
            get { return views; }
        }

        /// <summary>
        /// Adds the specified view instance to the composite view collection.
        /// </summary>
        public void Add(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            if (!(view is TView))
            {
                throw new ArgumentException(string.Format(
                    CultureInfo.InvariantCulture,
                    "Expected a view of type {0} but {1} was supplied.",
                    typeof(TView).FullName,
                    view.GetType().FullName
                ));
            }
            
            views.Add((TView)view);
        }

        /// <summary />
        public bool ThrowExceptionIfNoPresenterBound
        {
            get { return true; }
        }

        /// <summary>
        /// Occurs at the discretion of the view. 
        /// </summary>
        public abstract event EventHandler Load;
    }
}