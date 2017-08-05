using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WinFormsMvp.Messaging;

namespace WinFormsMvp.UnitTests
{
    [TestClass]
    public class MessengerRegisterUnregisterTest
    {
        public DateTime ReceivedContentDateTime1
        {
            get;
            private set;
        }

        public DateTime ReceivedContentDateTime2
        {
            get;
            private set;
        }

        public Exception ReceivedContentException
        {
            get;
            private set;
        }

        public int ReceivedContentInt
        {
            get;
            private set;
        }

        public string ReceivedContentStringA1
        {
            get;
            private set;
        }

        public string ReceivedContentStringA
        {
            get;
            private set;
        }

        public string ReceivedContentStringB
        {
            get;
            private set;
        }


        [TestMethod]
        public void TestRegisterSimpleTypes()
        {
            const string testContentString = "abcd";
            var testContentDateTime = DateTime.Now;
            const int testContentInt = 42;

            Reset();
            IMessageBus messageBus = new MessageBus();
            
            messageBus.Register<string>(this, TestConstants.MyStringToken, m => ReceivedContentStringA1 = m);
            messageBus.Register<DateTime>(this, TestConstants.MyDateTimeToken, m => ReceivedContentDateTime1 = m);
            messageBus.Register<int>(this, TestConstants.MyIntToken, m => ReceivedContentInt = m);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

             messageBus.Send(testContentString, TestConstants.MyStringToken);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            messageBus.Send(testContentDateTime, TestConstants.MyDateTimeToken);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            messageBus.Send(testContentInt, TestConstants.MyIntToken);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(testContentInt, ReceivedContentInt);
        }
        
        [TestMethod]
        public void TestUnRegisterObjectOnlyOverloadWithOneHandler()
        {
            const string testContentString = "abcd";
            const string testContentStringAfterUnregister = "efgh";

            Reset();
            IMessageBus messageBus = new MessageBus();
            
            messageBus.Register<string>(this, TestConstants.MyStringToken, m => ReceivedContentStringA1 = m);

            Assert.AreEqual(null, ReceivedContentStringA1);

            messageBus.Send(testContentString, TestConstants.MyStringToken);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);

            messageBus.Unregister<string>(this); // Use overload which just uses object

            messageBus.Send(testContentStringAfterUnregister, TestConstants.MyStringToken);

            Assert.AreNotEqual(testContentStringAfterUnregister, ReceivedContentStringA1);
        }
        
        [TestMethod]
        public void TestUnRegisterObjectOnlyOverloadWithMoreThanOneHandler()
        {
            const string testContentString1 = "abcd1";
            const string testContentString2 = "abcd2";
            const string testContentStringAfterUnregister = "efgh";

            Action<string> action1 = m => ReceivedContentStringA = m;
            Action<string> action2 = m => ReceivedContentStringA1 = m;
            Action<string> action3 = m => ReceivedContentStringB = m;
                
            Reset();
            IMessageBus messageBus = new MessageBus();
            
            messageBus.Register<string>(this, TestConstants.MyStringToken, action1);
            messageBus.Register<string>(this, TestConstants.MyStringToken, action2);
            messageBus.Register<string>(this, TestConstants.MyContentToken, action3);

            Assert.AreEqual(null, ReceivedContentStringA);
            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringB);

            messageBus.Send(testContentString1, TestConstants.MyStringToken);
            messageBus.Send(testContentString2, TestConstants.MyContentToken);

            Assert.AreEqual(testContentString1, ReceivedContentStringA);
            Assert.AreEqual(testContentString1, ReceivedContentStringA1);
            Assert.AreEqual(testContentString2, ReceivedContentStringB);

            messageBus.Unregister<string>(this); // Use overload which just uses object 

            messageBus.Send(testContentStringAfterUnregister, TestConstants.MyStringToken);
            messageBus.Send(testContentStringAfterUnregister, TestConstants.MyContentToken);

            Assert.AreNotEqual(testContentStringAfterUnregister, ReceivedContentStringA1);
            Assert.AreNotEqual(testContentStringAfterUnregister, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestUnregisterOneAction()
        {
            const string testContentA1 = "abcd";
            const string testContentA2 = "efgh";

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<TestMessageA> actionA1 = m => ReceivedContentStringA1 = m.Content;

            messageBus.Register(this, TestConstants.MyContentToken, actionA1);


            Assert.AreEqual(null, ReceivedContentStringA1);

            messageBus.Send(new TestMessageA
            {
                Content = testContentA1
            }, TestConstants.MyContentToken);

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);

            messageBus.Unregister(this, TestConstants.MyContentToken, actionA1);

            messageBus.Send(new TestMessageA
            {
                Content = testContentA2
            }, TestConstants.MyContentToken);


            Assert.AreNotEqual(testContentA2, ReceivedContentStringA1);
        }

        [TestMethod]
        public void InnerListIsEmptyAfterUnregisterIsCalled()
        {
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<string> action1 = m => ReceivedContentStringA1 = m;
            Action<string> action2 = m => ReceivedContentStringA = m;
            Action<string> action3 = m => ReceivedContentStringB = m;

            messageBus.Register(this, token1, action1);
            messageBus.Register(this, token2, action2);
            messageBus.Register(this, token2, action3);

            messageBus.Unregister(this, token1, action1);
            messageBus.Unregister(this, token2, action2);
            messageBus.Unregister(this, token2, action3);

            var type = typeof(MessageBus);

            // _commandCollection is an instance, private member
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = type.GetField("_recipientsStrictAction", flags);

            var innerRecipientsDictionary = field.GetValue(messageBus) as Dictionary<Type, List<MessageBus.WeakActionAndToken>>;

            Assert.IsFalse(innerRecipientsDictionary.Any());
        }
        
        [TestMethod]
        public void InnerListIsEmptyAfterUnregisterIsCalledWhereTwoActionsRegisteredForOneToken()
        {
            const int token2 = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<string> action2 = m => ReceivedContentStringA = m;
            Action<string> action3 = m => ReceivedContentStringB = m;

            messageBus.Register(this, token2, action2);
            messageBus.Register(this, token2, action3);

            //  Only unregister token2 and don't specify an action
            messageBus.Unregister<string>(this, token2);

            var type = typeof(MessageBus);

            // _commandCollection is an instance, private member
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = type.GetField("_recipientsStrictAction", flags);

            var innerRecipientsDictionary = field.GetValue(messageBus) as Dictionary<Type, List<MessageBus.WeakActionAndToken>>;

            Assert.IsFalse(innerRecipientsDictionary.Any());
        }
        
        [TestMethod]
        public void InnerListHasOneItemLeftAfterUnregisterIsCalledWhereTwoActionsRegisteredForOneTokenAndThereIsAThirdDifferentRegistration()
        {
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<string> action1 = m => ReceivedContentStringA1 = m;
            Action<string> action2 = m => ReceivedContentStringA = m;
            Action<string> action3 = m => ReceivedContentStringB = m;

            messageBus.Register(this, token1, action1);
            messageBus.Register(this, token2, action2);
            messageBus.Register(this, token2, action3);

            //  Only unregister token2 and don't specify an action
            messageBus.Unregister<string>(this, token2);

            var type = typeof(MessageBus);

            // _commandCollection is an instance, private member
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = type.GetField("_recipientsStrictAction", flags);

            var innerRecipientsDictionary = field.GetValue(messageBus) as Dictionary<Type, List<MessageBus.WeakActionAndToken>>;

            Assert.IsTrue(innerRecipientsDictionary.Count == 1);
            
        }

        [TestMethod]
        public void TestRegisterUnregisterOneActionWithToken()
        {
            const string testContent1 = "abcd";
            const string testContent2 = "efgh";
            const string testContent3 = "ijkl";
            const string testContent4 = "mnop";
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<string> action1 = m => ReceivedContentStringA1 = m;
            Action<string> action2 = m => ReceivedContentStringA = m;
            Action<string> action3 = m => ReceivedContentStringB = m;

            messageBus.Register(this, token1, action1);
            messageBus.Register(this, token2, action2);
            messageBus.Register(this, token2, action3);

            messageBus.Send(testContent1, token1);
            messageBus.Send(testContent2, token2);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA);
            Assert.AreEqual(testContent2, ReceivedContentStringB);

            messageBus.Unregister(this, token2, action3);
            messageBus.Send(testContent3, token1);
            messageBus.Send(testContent4, token2);

            Assert.AreEqual(testContent3, ReceivedContentStringA1);
            Assert.AreEqual(testContent4, ReceivedContentStringA);
            Assert.AreEqual(testContent2, ReceivedContentStringB);
        }  
        
        [TestMethod]
        public void InnerListHasOneItemAfterUnregisterIsCalledForSpecificActionWhereTwoActionsRegisteredForOneToken()
        {
            const string testContent1 = "efgh";
            const string testContent2 = "mnop";
            const int token = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            Action<string> action1 = m => ReceivedContentStringA = m;
            Action<string> action2 = m => ReceivedContentStringB = m;

            messageBus.Register(this, token, action1);
            messageBus.Register(this, token, action2);

            messageBus.Send(testContent1, token);

            Assert.AreEqual(testContent1, ReceivedContentStringA);
            Assert.AreEqual(testContent1, ReceivedContentStringB);

            messageBus.Unregister(this, token, action2); // only unregister action2. Leave action1.

            var type = typeof(MessageBus);

            // _commandCollection is an instance, private member
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = type.GetField("_recipientsStrictAction", flags);

            var innerRecipientsDictionary = field.GetValue(messageBus) as Dictionary<Type, List<MessageBus.WeakActionAndToken>>;

            messageBus.Send(testContent2, token);

            Assert.AreEqual(testContent2, ReceivedContentStringA);
            Assert.AreEqual(testContent1, ReceivedContentStringB);
            Assert.IsTrue(innerRecipientsDictionary.Count == 1);
        }

        [TestMethod]
        public void TestRegisterUnregisterWithToken()
        {
            const string testContent1 = "abcd";
            const string testContent2 = "efgh";
            const string testContent3 = "ijkl";
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            IMessageBus messageBus = new MessageBus();

            messageBus.Register<string>(this, token1, m => ReceivedContentStringA1 = m);
            messageBus.Register<string>(this, token2, m => ReceivedContentStringA = m);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA);

            messageBus.Send(testContent1, token1);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA);

            messageBus.Send(testContent2, token2);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA);

            messageBus.Unregister<string>(this, token1);
            messageBus.Send(testContent3, token1);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA);
        }

        //// Helpers

        private void Reset()
        {
            ReceivedContentStringA1 = null;
            ReceivedContentStringA = null;
            ReceivedContentStringB = null;
            ReceivedContentInt = default(int);

            ReceivedContentDateTime1 = DateTime.MinValue;
            ReceivedContentDateTime2 = DateTime.MinValue;
            ReceivedContentException = null;
        }

        public class TestMessageA
        {
            public string Content
            {
                get;
                set;
            }
        }

        public class TestMessageAa : TestMessageA
        {
        }

        public class TestMessageB
        {
            public string Content
            {
                get;
                set;
            }
        }

        public class TestMessageGenericBase
        {
        }

        private class TestRecipient
        {
            public string ReceivedContentA
            {
                get;
                private set;
            }

            public string ReceivedContentB
            {
                get;
                private set;
            }
        }

        private interface IMessage
        {
            string GetValue();
        }

        public class TestMessageImplementsIMessage : IMessage
        {
            private string Value
            {
                get;
                set;
            }

            public TestMessageImplementsIMessage(string value)
            {
                Value = value;
            }

            public string GetValue()
            {
                return Value;
            }
        }

    }

}
