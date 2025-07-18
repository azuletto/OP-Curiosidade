using OpCuriosidade.Notifications;
using OpCuriosidade.Validations.Interfaces;

namespace OpCuriosidade.Validations
{
    public partial class ContractValidations<T> where T : IContract
    {
        private List<Notification> _notifications;

        public ContractValidations()
        {
            _notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
        public bool isValid()
        {
            return _notifications.Count == 0 ? true: false;
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }
    }
}
