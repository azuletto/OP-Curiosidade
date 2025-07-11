using OpCuriosidade.Notifications;
namespace OpCuriosidade.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> IsValidBirthDate(DateOnly birthDate,string message,string properyName)
        {
            if (birthDate > DateOnly.FromDateTime(DateTime.Now))
            {
                AddNotification(new Notification(message, properyName));
                return this;
            }
            DateOnly maxBirthDate = DateOnly.FromDateTime(DateTime.Now).AddYears(-120);
            if (birthDate < maxBirthDate)
            {
                AddNotification(new Notification(message, properyName));
                return this;
            }
            if (DateOnly.FromDateTime(DateTime.Now).Year - birthDate.Year < 15)
            {
                AddNotification(new Notification(message, properyName));
                return this;
            }
            return this;
        }
    }
}
