using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> IsValidAdress(string addres, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(addres))
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        if (addres.Length < 5 || addres.Length > 100)
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        return this;
    }
}
