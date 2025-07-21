using Application.Output.DTO;
using Application.Output.Request.TableRequests;
using Application.Output.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.PersonContext
{
    internal interface IPersonRepository
    {
        void InsertPerson(PersonDTO person);
        Task<PersonDTO> GetPersonByIdAsync(Guid id);
        Task<PersonDTO> GetPersonByEmailAsync(string email);
        Task<PersonDTO> GetPersonByNameAsync(string name);
        Task<AdminRequest> GetAllPersonsAsync();
        IResultBase DeletePersonByIdAsync(Guid id);
    }
}
