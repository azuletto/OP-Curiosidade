using OpCuriosidade.Entities.PersonnelContext.ValueObjects;

namespace Application.Output.DTO
{
    public class PersonViewDataDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; }
    }
}
