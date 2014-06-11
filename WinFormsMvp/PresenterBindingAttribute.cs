using System;

namespace WinFormsMvp
{
    /// <summary>
    /// Used to define bindings between presenters and a views.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class PresenterBindingAttribute : Attribute
    {
        /// <summary />
        public PresenterBindingAttribute(Type presenterType)
        {
            PresenterType = presenterType;
            ViewType = null;
        }

        /// <summary />
        public Type PresenterType { get; private set; }
        
        /// <summary />
        public Type ViewType { get; set; }
    }
}