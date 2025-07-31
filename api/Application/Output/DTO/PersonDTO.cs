using OpCuriosidade.Entities.PersonnelContext.ValueObjects;

namespace Application.Output.DTO
{
    public struct PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; }
    }
}
