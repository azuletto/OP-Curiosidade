using Application.Mapper.Interface;
using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext;

namespace Application.Mapper
{
    public class PersonMapper : IMapperBase
    {
        public PersonDTO MapToDTO(Person person)
        {
            if (person == null)
            {
                return new PersonDTO();
            }
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                IsDeleted = person.IsDeleted,
                TimeStamp = person.TimeStamp,
                BirthDate = person.BirthDate,
                Status = person.Status,
                Address = person.Address,
                OtherInfos = person.OtherInfos
            };
        }
    }
}
