using Application.Input.Commands.PersonContext;
using Application.Input.Commands.PersonContext.ValueObjects;
using Application.Output.DTO;
using Application.Output.Request.TableRequests;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.Migrations;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.PersonContext
{
    public class PersonRepository(List<Person> personsDB) : IPersonRepository
    {
        public IResultBase DeletePersonByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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

            if (filterType.filterByName == true && (filterStatus == 0)) { filteredList = personsDB.OrderByDescending(p => p.Name).ToList(); }
                else if (filterType.filterByName == true && (filterStatus == 1)) { filteredList = personsDB.OrderBy(p => p.Name).ToList(); }
                    else if (filterType.filterByName == true && (filterStatus == 2)) { filteredList = personsDB; }
           
            if (filterType.filterByEmail == true && (filterStatus == 0 || filterStatus == 2)) { filteredList = personsDB.OrderByDescending(p => p.Email).ToList(); }
                else if (filterType.filterByName == true && (filterStatus == 1)) { filteredList = personsDB.OrderBy(p => p.Email).ToList(); }
                    else if (filterType.filterByName == true && (filterStatus == 2)) { filteredList = personsDB; }

            if (filterType.filterByStatus == true && (filterStatus == 0 || filterStatus == 2)) { filteredList = personsDB.OrderByDescending(p => p.Status).ToList(); }
                else if (filterType.filterByName == true && (filterStatus == 1)) { filteredList = personsDB.OrderBy(p => p.Status).ToList(); }
                    else if (filterType.filterByName == true && (filterStatus == 2)) { filteredList = personsDB; }

            if (filterType.filterByTimeStamp == true && (filterStatus == 0 || filterStatus == 2)) { filteredList = personsDB.OrderByDescending(p => p.TimeStamp).ToList(); }
                else if (filterType.filterByName == true && (filterStatus == 1)) { filteredList = personsDB.OrderBy(p => p.TimeStamp).ToList(); }
                    else if (filterType.filterByName == true && (filterStatus == 2)) { filteredList = personsDB; }

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

        public Task<PersonDTO> GetPersonByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetPersonByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void InsertPerson(PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
