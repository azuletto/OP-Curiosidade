using Application.Input.Commands.PersonContext;
using Application.Input.Commands.PersonContext.ValueObjects;
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
    public interface IPersonRepository
    {
        void InsertPerson(PersonDTO person);
        Task<PersonDTO> GetPersonByIdAsync(Guid id);
        Task<PersonDTO> GetPersonByEmailAsync(string email);
        Task<AdminRequest> GetPreviewDataToDashAsync();
        Task<PersonDTO> GetPersonByNameAsync(string name);
        Task<int> GetNumberOfPersonsAsync();
        Task<int> GetNumberOfPendingPersonsAsync();
        Task<int> GetNumberOfLastMonthPersonsAsync();
        Task<AdminRequest> GetAllPersonsAsync();
        IResultBase DeletePersonByIdAsync(Guid id);
    }
}
