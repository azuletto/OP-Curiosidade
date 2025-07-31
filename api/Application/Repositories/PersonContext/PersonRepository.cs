using Application.Input.Commands.PersonContext.ValueObjects;
using Application.Mapper;
using Application.Output.DTO;
using Application.Output.Request.TableRequests;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.Migrations;
using Application.Repositories.Validations;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;

namespace Application.Repositories.PersonContext
{
    public class PersonRepository(List<Person> personsDB) : IPersonRepository
    {
        public InsertValidationPerson InsertValidation { get; } = new(personsDB);
        public PersonMapper personMapper { get; } = new PersonMapper();

        public IResultBase DeletePersonByIdAsync(Guid id)
        {
            Result result;
            var person = personsDB.Find(person => person.Id == id);
            if (person == null)
            {
                result = new Result(resultCode: 404, message: "Person not found", isOk: false);
                Notification notification = new Notification("Pessoa não encontrada.", "notFound");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
            person.IsDeleted = true;
            result = new Result(resultCode: 200, message: "Person deleted successfully", isOk: true);
            result.SetData(personMapper.MapToDTO(person));
            return result;
        }

        public Task<AdminRequest> GetAllPersonsAsync()
        {
            Result result;
            AdminRequest adminRequest = new AdminRequest
            {
                Result = null,
                Persons = null
            };
            if (!personsDB.Any())
            {
                LoadPersons.Load(personsDB);
            }
            List<PersonDTO> personsDTO = personsDB
                .Where(person => !person.IsDeleted)
                .Select(person => new PersonDTO
                {
                    Email = person.Email,
                    Id = person.Id,
                    IsDeleted = person.IsDeleted,
                    Name = person.Name,
                    OtherInfos = person.OtherInfos,
                    Status = person.Status,
                    TimeStamp = person.TimeStamp
                })
        .ToList();
            result = new Result(resultCode: 200, message: "Pessoas encontradas com sucesso", isOk: true);
            adminRequest.Result = result;
            adminRequest.Persons = personsDTO;
            result.SetData(adminRequest.Persons);
            return Task.FromResult(adminRequest);
        }
        public Task<List<Person>> GetPersonsByFilter(FilterType filterType, int filterStatus)
        {
            List<Person> filteredList = new();
            filteredList = personsDB;

            Func<Person, object>? selector = filterType switch
            {
                { filterByName: true } => p => p.Name,
                { filterByStatus: true } => p => p.Status,
                { filterByEmail: true } => p => p.Email,
                { filterByTimeStamp: true } => p => p.TimeStamp,
                _ => null
            };

            filteredList = (selector, filterStatus) switch
            {
                (not null, 0) => personsDB.OrderByDescending(selector).ToList(),
                (not null, 1) => personsDB.OrderBy(selector).ToList(),
                (not null, 2) => personsDB,
                _ => personsDB
            };

            return Task.FromResult(filteredList);
        }
        public async Task<AdminRequest> GetPreviewDataToDashAsync()
        {
            Result result;
            AdminRequest adminRequest = new AdminRequest
            {
                Result = null,
                Persons = null
            };
            if (!personsDB.Any())
            {
                LoadPersons.Load(personsDB);
            }
            FilterType filterType = new() { filterByTimeStamp = true };

            var persons = await GetPersonsByFilter(filterType, filterStatus: 0);

            List<PersonDTO> personsDTO = persons
                .Where(person => !person.IsDeleted)
                .Select(person => new PersonDTO
                {
                    Email = person.Email,
                    Id = person.Id,
                    IsDeleted = person.IsDeleted,
                    Name = person.Name,
                    OtherInfos = person.OtherInfos,
                    Status = person.Status,
                    TimeStamp = person.TimeStamp
                })
                .Take(10)
                .ToList();

            result = new Result(resultCode: 200, message: "Pessoas encontradas com sucesso", isOk: true);
            adminRequest.Result = result;
            adminRequest.Persons = personsDTO;
            result.SetData(adminRequest.Persons);
            return adminRequest;
        }
        public Task<int> GetNumberOfLastMonthPersonsAsync()
        {
            var thisMonth = DateTime.Now.Month;
            int count = personsDB
                .Count(person => person.TimeStamp.Month == thisMonth && !person.IsDeleted);
            return Task.FromResult(count);
        }

        public Task<int> GetNumberOfPendingPersonsAsync()
        {
            var count = personsDB
                .Count(person => person.Status == false && !person.IsDeleted);
            return Task.FromResult(count);
        }

        public Task<int> GetNumberOfPersonsAsync()
        {
            var count = personsDB
                .Count(person => !person.IsDeleted);
            return Task.FromResult(count);
        }

        public Task<PersonDTO> GetPersonByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<PersonViewDataDTO> GetPersonByIdAsync(Guid id)
        {
            PersonViewDataMapper mapper = new PersonViewDataMapper();
            Person person = personsDB
                .FirstOrDefault(person => person.Id == id && !person.IsDeleted);
            if (person == null || person.IsDeleted)
            {
                Result result = new Result(resultCode: 404, message: "Person not found", isOk: false);
            }
            PersonViewDataDTO personViewDataDTO = mapper.MapToViewDTO(person);
            return Task.FromResult(personViewDataDTO);
        }

        public Task<PersonDTO> GetPersonByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public IResultBase InsertPerson(Person person)
        {
            Result result;
            if (InsertValidation.IsPersonAlreadyRegistered(person.Email) == false)
            {
                result = new Result(resultCode: 201, message: "Pessoa criada com sucesso.", isOk: true);
                personsDB.Add(person);
                result.SetData(personMapper.MapToDTO(person));
                return result;
            }
            else
            {
                result = new Result(resultCode: 400, message: "Pessoa já existente", isOk: false);
                Notification notification = new Notification("O email já está sendo utilizado. Tente novamente.", "alreadyDb");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
        }
        public IResultBase UpdatePersonAsync(PersonDTO personDTO)
        {
            Result result;

            var personToEdit = personsDB.Find(personToEdit => personToEdit.Id == personDTO.Id);
            if (personToEdit == null)
            {
                result = new Result(resultCode: 404, message: "Person not found", isOk: false);
                Notification notification = new Notification("Registro não encontrado.", "notFound");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
            personToEdit.Name = personDTO.Name;
            personToEdit.Email = personDTO.Email;
            personToEdit.BirthDate = personDTO.BirthDate;
            personToEdit.Status = personDTO.Status;
            personToEdit.Address = personDTO.Address;
            personToEdit.OtherInfos = personDTO.OtherInfos;

            if (personToEdit.Validation() == false)
            {
                result = new Result(resultCode: 400, message: "Erro na criação do registro", isOk: false);
                return result;
            }

            personsDB[personsDB.IndexOf(personToEdit)] = personToEdit;
            result = new Result(resultCode: 200, message: "Dados do registro atualizados com sucesso.", isOk: true);
            result.SetData(personMapper.MapToDTO(personToEdit));
            return result;
        }

    }
}
