using Application.Mapper.Interface;
using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext;

namespace Application.Mapper
{
    public class PersonViewDataMapper : IMapperBase
    {
        public PersonViewDataDTO MapToViewDTO(Person person)
        {
            if (person == null)
            {
                return new PersonViewDataDTO();
            }
            return new PersonViewDataDTO
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                BirthDate = person.BirthDate,
                Status = person.Status,
                Address = person.Address,
                OtherInfos = person.OtherInfos
            };
        }
    }
}
