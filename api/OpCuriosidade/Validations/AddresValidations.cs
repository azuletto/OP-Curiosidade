using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> IsValidAdress(string address, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(address) || address == "")
        {
            Console.WriteLine("Address is null or empty");
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        if (address.Length < 5 || address.Length > 100)
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        return this;
    }
}
