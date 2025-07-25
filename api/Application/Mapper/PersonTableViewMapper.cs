using Application.Mapper.Interface;
using Application.Output.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                TimeStamp = person.TimeStamp,
                Status = person.Status
            }).ToList();
        }
    }
}
