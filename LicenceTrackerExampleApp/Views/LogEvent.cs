namespace LicenceTracker.Views
{
    public class LogEvent
    {
        public string Event { get; set; }

        public override string ToString()
        {
            return Event;
        }
    }
}