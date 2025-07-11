using OpCuriosidade.Validations;
using OpCuriosidade.Validations.Interfaces;
using OpCuriosidade.ValueObjects;

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
            string addres,
            OtherInfos ? otherInfos = null
            )
            : base(name, email, isDeleted)
        {
            BirthDate = birthDate;
            Status = status;
            Addres = addres;
            OtherInfos = otherInfos;
        }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Addres { get; set; }
        public OtherInfos ? OtherInfos { get; set; }
        public override bool Validation()
        {
            var constracts = new ContractValidations<Person>();
            return true;
        }
    }
}
