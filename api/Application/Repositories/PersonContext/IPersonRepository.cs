using Application.Input.Commands.PersonContext.ValueObjects;
using Application.Output.DTO;
using Application.Output.Request.TableRequests;
using Application.Output.Results.Interfaces;
using OpCuriosidade.Entities.PersonnelContext;

namespace Application.Repositories.PersonContext
{
    public interface IPersonRepository
    {
        IResultBase InsertPerson(Person person);
        Task<PersonViewDataDTO> GetPersonByIdAsync(Guid id);
        Task<AdminRequest> GetPersonByEmailAsync(string email);
        Task<AdminRequest> GetPreviewDataToDashAsync(int skipTable, int filterStatus, FilterType filterType);
        Task<AdminRequest> GetPersonByNameAsync(string name);
        Task<int> GetNumberOfPersonsAsync();
        Task<int> GetNumberOfPendingPersonsAsync();
        Task<int> GetNumberOfLastMonthPersonsAsync();
        Task<AdminRequest> GetAllPersonsAsync();
        IResultBase DeletePersonByIdAsync(Guid id);
        IResultBase UpdatePersonAsync(PersonViewDataDTO personDTO);
    }
}
