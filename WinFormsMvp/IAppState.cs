using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMvp
{
    public interface IAppState
    {
        void AddItem<T>(string key, T item);
        T GetItem<T>(string key);
        void RemoveItem<T>(string key);
    }
}
