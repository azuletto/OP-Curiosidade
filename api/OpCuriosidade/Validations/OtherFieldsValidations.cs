using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using OpCuriosidade.Notifications;
using System.Text.RegularExpressions;

namespace OpCuriosidade.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> IsValidOtherInfos(OtherInfos? otherInfos, string propertyName)
    {
        if (otherInfos == null)
            return this; // Opcional: considere AddNotification se null for inválido

        IsSafeString(otherInfos.Valors, "Valors contém caracteres perigosos", $"{propertyName}.Valors");
        IsSafeString(otherInfos.Feelings, "Feelings contém caracteres perigosos", $"{propertyName}.Feelings");
        IsSafeString(otherInfos.Info, "Info contém caracteres perigosos", $"{propertyName}.Info");
        IsSafeString(otherInfos.Interess, "Interess contém caracteres perigosos", $"{propertyName}.Interess");

        return this;
    }

    public ContractValidations<T> IsSafeString(string? value, string message, string propertyName)
    {
        if (string.IsNullOrEmpty(value))
            return this;

        var dangerousCharsPattern = new Regex(@"[\;'""><%&|^~`{}]");

        if (dangerousCharsPattern.IsMatch(value))
        {
            AddNotification(new Notification(message, propertyName));
        }
        return this;
    }
}