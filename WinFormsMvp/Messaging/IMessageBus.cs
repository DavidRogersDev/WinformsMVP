using System;

namespace WinFormsMvp.Messaging
{
    public interface IMessageBus
    {
        void Register<TMessage>(object recipient, object token, Action<TMessage> action);
        void Send<TMessage>(TMessage message, object token);
        void Unregister<TMessage>(object recipient);
        void Unregister<TMessage>(object recipient, object token);
        void Unregister<TMessage>(object recipient, object token, Action<TMessage> action);
    }
}
