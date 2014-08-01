// ****************************************************************************
//  Based on messenger class in MVVM Light toolkit
// <copyright file="NotificationMessageGeneric.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2011
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>13.4.2009</date>
// <project>GalaSoft.MvvmLight.Messaging</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsMvp.Messaging
{
    public class MessageBus : IMessageBus
    {
        readonly Dictionary<Type, List<WeakActionAndToken>> _recipientsStrictAction = new Dictionary<Type, List<WeakActionAndToken>>();

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

            CleanupList(_recipientsStrictAction);
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

            CleanupList(_recipientsStrictAction);
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

        private static void CleanupList(IDictionary<Type, List<WeakActionAndToken>> lists)
        {
            if (lists == null)
            {
                return;
            }

            lock (lists)
            {
                var listsToRemove = new List<Type>();
                foreach (var list in lists)
                {
                    var recipientsToRemove = list.Value.Where(item => item.Action == null || !item.Action.IsAlive).ToList();

                    foreach (WeakActionAndToken recipient in recipientsToRemove)
                    {
                        list.Value.Remove(recipient);
                    }

                    if (list.Value.Count == 0)
                    {
                        listsToRemove.Add(list.Key);
                    }
                }

                foreach (Type key in listsToRemove)
                {
                    lists.Remove(key);
                }
            }
        }

        private static bool Implements(Type instanceType, Type interfaceType)
        {
            if (interfaceType == null || instanceType == null)
                return false;

            Type[] interfaces = instanceType.GetInterfaces();

            return interfaces.Any(currentInterface => currentInterface == interfaceType);
        }

        public virtual void Unregister<TMessage>(object recipient)
        {
            Unregister<TMessage>(recipient, null, null);
        }


        public virtual void Unregister<TMessage>(object recipient, object token)
        {
            Unregister<TMessage>(recipient, token, null);
        }

        public virtual void Unregister<TMessage>(object recipient, object token, Action<TMessage> action)
        {
            UnregisterFromLists(recipient, token, action, _recipientsStrictAction);
            CleanupList(_recipientsStrictAction);
        }

        private static void UnregisterFromLists<TMessage>(
                    object recipient,
                    object token,
                    Action<TMessage> action,
                    Dictionary<Type, List<WeakActionAndToken>> lists)
        {
            Type messageType = typeof(TMessage);

            if (recipient == null || lists == null || lists.Count == 0 || !lists.ContainsKey(messageType))
                return;

            lock (lists)
            {
                foreach (WeakActionAndToken item in lists[messageType])
                {
                    var weakActionCasted = item.Action as WeakAction<TMessage>;

                    if (weakActionCasted != null && recipient == weakActionCasted.Target
                        && (action == null || action == weakActionCasted.Action)
                        && (token == null || token.Equals(item.Token)))
                    {
                        item.Action.MarkForDeletion();
                    }
                }
            }
        }


        internal struct WeakActionAndToken
        {
            public WeakAction Action;

            public object Token;
             
        }
    }
}
