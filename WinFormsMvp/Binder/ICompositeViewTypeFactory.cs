using System;

namespace WinFormsMvp.Binder
{
    internal interface ICompositeViewTypeFactory
    {
        Type BuildCompositeViewType(Type viewType);
    }
}
