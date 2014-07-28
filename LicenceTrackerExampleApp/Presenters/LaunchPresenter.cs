using LicenceTracker.Entities;
using LicenceTracker.Views;
using System;
using System.ComponentModel;
using WinFormsMvp;
using WinFormsMvp.Binder;
using WinFormsMvp.Messaging;

namespace LicenceTracker.Presenters
{
    public class LaunchPresenter : Presenter<ILaunchView>
    {
        public LaunchPresenter(ILaunchView view)
            : base(view)
        {
            View.AddPersonClicked += View_AddPersonClicked;
            View.AddSoftwareClicked += View_AddSoftwareClicked;
            View.CloseFormClicked += View_CloseFormClicked;
            View.Load += View_Load;

            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            PresenterBinder.MessageBus.Register(this,
                Constants.PersonAddedToken,
                new Action<GenericMessage<Person>>(LogPersonAddedEvent)
                );

            PresenterBinder.MessageBus.Register(this,
                Constants.ProductAddedToken,
                new Action<GenericMessage<Software>>(LogProductAddedEvent)
                );

            PresenterBinder.MessageBus.Register(this,
                Constants.SoftwareTypeAddedToken,
                new Action<GenericMessage<SoftwareType>>(LogSoftwareFileAddedEvent)
                );
        }

        private void LogSoftwareFileAddedEvent(GenericMessage<SoftwareType> message)
        {
            View.LiveLog.Add(
                new LogEvent
                {
                    Event = string.Format("Software Type with name {0} added",
                        message.Content.Name)
                });
        }

        private void LogProductAddedEvent(GenericMessage<Software> message)
        {
            View.LiveLog.Add(
                new LogEvent
                {
                    Event = string.Format("Product with name {0} added",
                        message.Content.Name)
                });
        }

        private void LogPersonAddedEvent(GenericMessage<Person> message)
        {
            View.LiveLog.Add(
                new LogEvent { Event = string.Format("Person with name {0} added", 
                message.Content.FirstName + " " + message.Content.LastName) }
                );
        }

        void View_AddSoftwareClicked(object sender, EventArgs e)
        {
            View.ShowAddProductView();
        }

        void View_AddPersonClicked(object sender, EventArgs e)
        {
            View.ShowAddPersonView();
        }

        void View_Load(object sender, EventArgs e)
        {
            View.LiveLog = new BindingList<LogEvent> { new LogEvent { Event = "App Loaded" } };
        }

        void View_CloseFormClicked(object sender, EventArgs e)
        {
            PresenterBinder.MessageBus.Unregister(this, Constants.MyToken, new Action<GenericMessage<Person>>(LogPersonAddedEvent));
            
            View.Exit();
        }
    }
}
