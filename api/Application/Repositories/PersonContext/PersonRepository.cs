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
                result = new Result(resultCode: 200, message: "Pessoas carregadas com sucesso", isOk: true);
                adminRequest.Result = result;
                return Task.FromResult(adminRequest);
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

        public Task<IResultBase> GetFilteredAsync(FilterType filterType, bool inDashboard, int filterStatus)
        {
            Result result;
            var users = personsDB
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

            if (filterType.filterByTimeStamp == true && inDashboard == true)
            {
                var orderedUsers = users.OrderByDescending(user => user.TimeStamp).ToList();
                result = new Result(resultCode: 200, message: "Pessoas filtradas por timestamp com sucesso", isOk: true);
                result.SetData(users);
                return Task.FromResult<IResultBase>(result);
            }
            if (filterType.filterByEmail == true)
            {
                var orderedUsers = users.OrderByDescending(user => user.Email).ToList();
                result = new Result(resultCode: 200, message: "Pessoas filtradas por email com sucesso", isOk: true);
                result.SetData(users);
                return Task.FromResult<IResultBase>(result);
            }
            if (filterType.filterByName == true)
            {
                var orderedUsers = users.OrderByDescending(user => user.Name).ToList();
                result = new Result(resultCode: 200, message: "Pessoas filtradas por nome com sucesso", isOk: true);
                result.SetData(users);
                return Task.FromResult<IResultBase>(result);
            }
            if (filterType.filterByStatus == true)
            {
                var orderedUsers = users.OrderByDescending(user => user.Status).ToList();
                result = new Result(resultCode: 200, message: "Pessoas filtradas por status com sucesso", isOk: true);
                result.SetData(users);
                return Task.FromResult<IResultBase>(result);
            }
            result = new Result(resultCode: 400, message: "Filtro inválido", isOk: false);
            return Task.FromResult<IResultBase>(result);
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
