using Application.Repositories.Notifications.Interface;

namespace Application.Repositories.Notifications
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
