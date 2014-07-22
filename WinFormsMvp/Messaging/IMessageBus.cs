using System;

namespace WinFormsMvp.Messaging
{
    public interface IMessageBus
    {
        void Send<TMessage>(TMessage message, object token);
        void Register<TMessage>(object recipient, object token, Action<TMessage> action);
    }
}
