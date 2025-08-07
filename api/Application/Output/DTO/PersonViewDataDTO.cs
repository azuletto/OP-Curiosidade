using Application.Repositories.Validations;
using Application.Repositories.Validations.Interfaces;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;

namespace Application.Output.DTO
{
    public class PersonViewDataDTO : IContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; }

        public bool Validation()
        {
            var contracts = new ContractValidations<PersonViewDataDTO>()
                .IsValidName(name: Name, message: "O nome é inválido", propertyName: "name")
                .isValidEmail(email: Email, message: "O email é inválido", propertyName: "email")
                .IsValidBirthDate(birthDate: BirthDate, message: "A data de nascimento é inválida", propertyName: "birthDate")
                .IsValidAdress(address: Address, message: "O endereço é inválido", propertyName: "addres")
                .IsValidOtherInfos(OtherInfos, propertyName: "otherInfos");
            return contracts.isValid();
        }
    }
}

