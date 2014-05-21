using System;

namespace WinFormsMvp.Binder
{
    /// <summary/>
    public class PresenterBinding
    {
        readonly Type presenterType;
        readonly Type viewType;
        readonly IView viewInstance;

        /// <summary/>
        public PresenterBinding(
            Type presenterType,
            Type viewType,
            IView viewInstance)
        {
            this.presenterType = presenterType;
            this.viewType = viewType;
            this.viewInstance = viewInstance;
        }

        /// <summary/>
        public Type PresenterType
        {
            get { return presenterType; }
        }

        /// <summary/>
        public Type ViewType
        {
            get { return viewType; }
        }
        
        /// <summary/>
        public IView ViewInstance
        {
            get { return viewInstance; }
        }

        /// <summary>
        /// Determines whether the specified <see cref="PresenterBinding"/> is equal to the current <see cref="PresenterBinding"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="PresenterBinding"/> is equal to the current <see cref="PresenterBinding"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="PresenterBinding"/> to compare with the current <see cref="PresenterBinding"/>.</param>
        public override bool Equals(object obj)
        {
            var target = obj as PresenterBinding;
            if (target == null) return false;

            return
                PresenterType == target.PresenterType &&
                ViewType == target.ViewType &&
                ViewInstance.Equals(target.ViewInstance); // todo: override Equals of IView perhaps.
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="PresenterBinding"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return
                PresenterType.GetHashCode() |
                ViewType.GetHashCode() |
                ViewInstance.GetHashCode();
        }
    }
}