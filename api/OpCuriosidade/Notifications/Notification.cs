using OpCuriosidade.Notifications.Interface;

namespace OpCuriosidade.Notifications
{
    public class Notification : INotification
    {
        public Notification(string message, string property)
        {
            Message = message;
            Property = property;
        }

        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
