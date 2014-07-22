
namespace WinFormsMvp.Messaging
{
    /// <summary>
    /// This interface is meant for the <see cref="WeakAction{T}" /> class and can be 
    /// useful if you store multiple WeakAction{T} instances but don't know in advance
    /// what type T represents.
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    public interface IExecuteWithObject
    {
        /// <summary>
        /// Executes an action.
        /// </summary>
        /// <param name="parameter">A parameter passed as an object,
        /// to be casted to the appropriate type.</param>
        void ExecuteWithObject(object parameter);
    }
}