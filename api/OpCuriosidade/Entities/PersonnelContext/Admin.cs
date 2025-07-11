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
            var contracts = new ContractValidations<Admin>();
            return true;
        }
    }
}