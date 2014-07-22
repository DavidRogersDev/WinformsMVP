using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsMvp.Messaging
{
    public class MessageBus : IMessageBus
    {
        Dictionary<Type, List<WeakActionAndToken>> _recipientsStrictAction = new Dictionary<Type, List<WeakActionAndToken>>();

        public void Register<TMessage>(object recipient, object token, Action<TMessage> action)
        {
            Type messageType = typeof(TMessage);

            Dictionary<Type, List<WeakActionAndToken>> recipients = _recipientsStrictAction;

            lock (recipients)
            {
                List<WeakActionAndToken> list;

                if (!recipients.ContainsKey(messageType))
                {
                    list = new List<WeakActionAndToken>();
                    recipients.Add(messageType, list);
                }
                else
                {
                    list = recipients[messageType];
                }

                var weakAction = new WeakAction<TMessage>(recipient, action);
                var item = new WeakActionAndToken
                {
                    Action = weakAction,
                    Token = token
                };
                list.Add(item);
            }
        }

        public virtual void Send<TMessage>(TMessage message, object token)
        {
            SendToTargetOrType(message, null, token);
        }

        private void SendToTargetOrType<TMessage>(TMessage message, Type messageTargetType, object token)
        {
            Type messageType = message.GetType();

            if (_recipientsStrictAction != null)
            {
                if (_recipientsStrictAction.ContainsKey(messageType))
                {
                    List<WeakActionAndToken> list = null;

                    lock (_recipientsStrictAction)
                    {
                        list = _recipientsStrictAction[messageType].Take(_recipientsStrictAction[messageType].Count()).ToList();
                    }

                    SendToList(message, list, messageTargetType, token);
                }
            }

            //Cleanup();
        }

        private static void SendToList<TMessage>(
            TMessage message,
            IEnumerable<WeakActionAndToken> list,
            Type messageTargetType,
            object token)
        {
            if (list != null)
            {
                // Clone to protect from people registering in a "receive message" method
                // Bug correction Messaging BL0004.007
                List<WeakActionAndToken> listClone = list.Take(list.Count()).ToList();

                foreach (WeakActionAndToken item in listClone)
                {
                    var executeAction = item.Action as IExecuteWithObject;

                    if (executeAction != null
                        && item.Action.IsAlive
                        && item.Action.Target != null
                        && (messageTargetType == null
                            || item.Action.Target.GetType() == messageTargetType
                            || Implements(item.Action.Target.GetType(), messageTargetType))
                        && ((item.Token == null && token == null)
                            || item.Token != null && item.Token.Equals(token)))
                    {
                        executeAction.ExecuteWithObject(message);
                    }
                }
            }
        }

        private static bool Implements(Type instanceType, Type interfaceType)
        {
            if (interfaceType == null
                || instanceType == null)
            {
                return false;
            }

            Type[] interfaces = instanceType.GetInterfaces();

            foreach (Type currentInterface in interfaces)
            {
                if (currentInterface == interfaceType)
                {
                    return true;
                }
            }

            return false;
        }

        private struct WeakActionAndToken
        {
            public WeakAction Action;

            public object Token;
             
        }
    }
}
