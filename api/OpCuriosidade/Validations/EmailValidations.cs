using System.Text.RegularExpressions;
using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> isValidEmail(string email, string message, string propertyName)
        {
            if (email == null)
            {
                AddNotification(new Notification(message, propertyName));
                return this;
            }
            if (email.Length == 0)
            {
                AddNotification(new Notification(message, propertyName));
                return this;
            }
            string emailPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            Regex regex = new Regex(emailPattern);
            if (!regex.IsMatch(email))
            {
                AddNotification(new Notification(message, propertyName));
                return this;
            }
            return this;
        }
    }
}
