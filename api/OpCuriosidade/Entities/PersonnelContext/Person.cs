using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using OpCuriosidade.Validations;
using OpCuriosidade.Validations.Interfaces;

namespace OpCuriosidade.Entities.PersonnelContext
{
    public class Person : BaseEntity, IContract
    {
        public Person
            (
            string name,
            string email,
            bool isDeleted,
            DateOnly birthDate,
            bool status,
            string address,
            OtherInfos? otherInfos = null
            )
            : base(name, email, isDeleted)
        {
            BirthDate = birthDate;
            Status = status;
            Address = address;
            OtherInfos = otherInfos;
        }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; }
        public override bool Validation()
        {
            var contracts = new ContractValidations<Person>()
                .IsValidName(name: Name, message: "O nome é inválido", propertyName: "name")
                .isValidEmail(email: Email, message: "O email é inválido", propertyName: "email")
                .IsValidBirthDate(birthDate: BirthDate, message: "A data de nascimento é inválida", propertyName: "birthDate")
                .IsValidAdress(address: Address, message: "O endereço é inválido", propertyName: "addres")
                .IsValidOtherInfos(OtherInfos, propertyName: "otherInfos");
            return contracts.isValid();
        }
    }
}
