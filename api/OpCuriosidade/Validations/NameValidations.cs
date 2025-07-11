using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> IsValidName(string name, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(name))
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        if (name.Length < 2 || name.Length > 50)
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c) && c != '-' && c != '\'')
            {
                AddNotification(new Notification(message, propertyName));
                return this;
            }
        }
        return this;
    }
}
