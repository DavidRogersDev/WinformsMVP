
namespace WinFormsMvp
{
    public interface IAppState
    {
        void AddItem<T>(string key, T item);
        void Clear();
        T GetItem<T>(string key);
        bool HasItem(string key);
        void RemoveItem<T>(string key);
    }
}
