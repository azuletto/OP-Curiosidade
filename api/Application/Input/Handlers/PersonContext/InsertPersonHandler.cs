using Application.Input.Commands.AdminContext;
using Application.Input.Commands.PersonContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using Application.Repositories.PersonContext;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.PersonContext
{
    public class InsertPersonHandler : IHandlerBase<InsertPersonCommand>
    {
        private readonly IPersonRepository _repository;
        public InsertPersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IResultBase Handle(InsertPersonCommand command)
        {
            Result result;

            var person = new 
                Person(
                command.Name,
                command.Email,
                command.DateOfBirth,
                command.Status,
                command.Address,
                command.OtherInfos
                );
            if (person.Validation())
            {
                try
                {
                    result = (Result)_repository.InsertPerson(person);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Erro ao inserir pessoa: {ex.Message}", false);
                    return result;
                }
            }
            result = new Result(400, "", false);
            var contracts = person.Validation(true);
            result.SetNotifications(contracts.GetNotifications());
            return result;
        }
    }
}
