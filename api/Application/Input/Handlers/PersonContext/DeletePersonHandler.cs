using Application.Input.Commands.AdminContext;
using Application.Input.Commands.PersonContext;
using Application.Output.DTO;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using Application.Repositories.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.PersonContext
{
    public class DeletePersonHandler
    {
        private readonly IPersonRepository _repository;
        public DeletePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(DeletePersonCommand command)
        {
            Result result;
            PersonDTO deletePersonDTO = new()
            {
                Id = command.Id
            };
            if (deletePersonDTO.IsDeleted == true)
            {
                result = new Result(400, "Essa pessoa já está deletada", false);

                return result;
            }
            try
            {
                result = (Result)_repository.DeletePersonByIdAsync(deletePersonDTO.Id);
                return result;
            }
            catch (Exception ex)
            {
                return result = new Result(500, $"Erro ao deletar admin: {ex.Message}", false);
            }
        }
    }
}
