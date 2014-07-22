using System;

namespace WinFormsMvp.Messaging
{
    public class WeakAction<T> : WeakAction, IExecuteWithObject
    {
        private readonly Action<T> _action;

        /// <summary>
        /// Initializes a new instance of the WeakAction class.
        /// </summary>
        /// <param name="target">The action's owner.</param>
        /// <param name="action">The action that will be associated to this instance.</param>
        public WeakAction(object target, Action<T> action)
            : base(target, null)
        {
            _action = action;
        }

        /// <summary>
        /// Gets the Action associated to this instance.
        /// </summary>
        public new Action<T> Action
        {
            get
            {
                return _action;
            }
        }

        /// <summary>
        /// Executes the action. This only happens if the action's owner
        /// is still alive. The action's parameter is set to default(T).
        /// </summary>
        public new void Execute()
        {
            if (_action != null
                && IsAlive)
            {
                _action(default(T));
            }
        }

        /// <summary>
        /// Executes the action. This only happens if the action's owner
        /// is still alive.
        /// </summary>
        /// <param name="parameter">A parameter to be passed to the action.</param>
        public void Execute(T parameter)
        {
            if (_action != null
                && IsAlive)
            {
                _action(parameter);
            }
        }

        /// <summary>
        /// Executes the action with a parameter of type object. This parameter
        /// will be casted to T. This method implements <see cref="IExecuteWithObject.ExecuteWithObject" />
        /// and can be useful if you store multiple WeakAction{T} instances but don't know in advance
        /// what type T represents.
        /// </summary>
        /// <param name="parameter">The parameter that will be passed to the action after
        /// being casted to T.</param>
        public void ExecuteWithObject(object parameter)
        {
            var parameterCasted = (T)parameter;
            Execute(parameterCasted);
        }
          
    }

    public class WeakAction
    {
        private readonly Action _action;

        private WeakReference _reference;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction" /> class.
        /// </summary>
        /// <param name="target">The action's owner.</param>
        /// <param name="action">The action that will be associated to this instance.</param>
        public WeakAction(object target, Action action)
        {
            _reference = new WeakReference(target);
            _action = action;
        }

        /// <summary>
        /// Gets the Action associated to this instance.
        /// </summary>
        public Action Action
        {
            get
            {
                return _action;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Action's owner is still alive, or if it was collected
        /// by the Garbage Collector already.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (_reference == null)
                {
                    return false;
                }

                return _reference.IsAlive;
            }
        }

        /// <summary>
        /// Gets the Action's owner. This object is stored as a <see cref="WeakReference" />.
        /// </summary>
        public object Target
        {
            get
            {
                if (_reference == null)
                {
                    return null;
                }

                return _reference.Target;
            }
        }

        /// <summary>
        /// Executes the action. This only happens if the action's owner
        /// is still alive.
        /// </summary>
        public void Execute()
        {
            if (_action != null
                && IsAlive)
            {
                _action();
            }
        }

        /// <summary>
        /// Sets the reference that this instance stores to null.
        /// </summary>
        public void MarkForDeletion()
        {
            _reference = null;
        }
 
    }
}
