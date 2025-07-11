using OpCuriosidade.Notifications;
using OpCuriosidade.Validations.Interfaces;
namespace OpCuriosidade.Entities.PersonnelContext
{
    public abstract class BaseEntity : IValidations
    {
        private List<Notification> _notifications = new List<Notification>();
        protected BaseEntity(string name, string email, bool isDeleted)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            IsDeleted = isDeleted;
            TimeStamp = DateTime.UtcNow;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        protected void SetNotificationsList(List<Notification> notifications)
        {
            _notifications = notifications ?? new List<Notification>();
        }
        public abstract bool Validation();
    }
}
