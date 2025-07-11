using OpCuriosidade.Validations;
using OpCuriosidade.Validations.Interfaces;

namespace OpCuriosidade.Entities.PersonnelContext
{
    public class Admin : BaseEntity, IContract
    {
        public Admin(string name, string email, bool isDeleted, string password)
            : base(name, email, isDeleted)
        {
            Password = password;
        }
        public string Password { get; private set; }
        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public override bool Validation()
        {
            var contracts = new ContractValidations<Admin>()
                .IsValidName(name: Name, message: "O nome é inválido", propertyName: "name")
                .isValidEmail(email: Email, message: "O email é inválido", propertyName: "email")
                .IsValidPassword(password: Password, message: "A senha é inválida", propertyName: "password");
            return contracts.isValid();
        }
    }
}