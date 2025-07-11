using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> IsValidPassword(string password, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(password))
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        if (password.Length < 6 || password.Length > 100)
        {
            AddNotification(new Notification(message, propertyName));
            return this;
        }
        switch (password)
        {
            case var _ when !HasUpperCase(password):
                AddNotification(new Notification(message, propertyName));
                return this;
            case var _ when !HasLowerCase(password):
                AddNotification(new Notification(message, propertyName));
                return this;
            case var _ when !HasDigit(password):
                AddNotification(new Notification(message, propertyName));
                return this;
            case var _ when !HasSpecialCharacter(password):
                AddNotification(new Notification(message, propertyName));
                return this;
        }
        return this;
    }
    private static bool HasUpperCase(string password)
    {
        return password.Any(char.IsUpper);
    }
    private static bool HasLowerCase(string password)
    {
        return password.Any(char.IsLower);
    }
    private static bool HasDigit(string password)
    {
        return password.Any(char.IsDigit);
    }
    public static bool HasSpecialCharacter(string password)
    {
        string specialCharacters = "!@#$%^&*()-_=+[]{}|;:',.<>?/";
        return password.Any(c => specialCharacters.Contains(c));
    }
}
