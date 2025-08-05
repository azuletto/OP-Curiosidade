using Application.Mapper.Interface;
using Application.Output.DTO;

namespace Application.Mapper
{
    public class PersonTableViewMapper : IMapperBase
    {
        public static List<PersonTableViewDTO> MapToTableView(List<PersonDTO> persons)
        {
            if (persons == null || !persons.Any())
            {
                return new List<PersonTableViewDTO>();
            }
            return persons.Select(person => new PersonTableViewDTO
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                TimeStamp = (DateTime)person.TimeStamp,
                Status = person.Status
            }).ToList();
        }
    }
}
