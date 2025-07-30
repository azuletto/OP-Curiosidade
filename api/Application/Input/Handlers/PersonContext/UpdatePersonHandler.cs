using Application.Input.Commands.AdminContext;
using Application.Input.Commands.PersonContext;
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
    public class UpdatePersonHandler
    {
        private readonly IPersonRepository _repository;
        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(UpdatePersonCommand command)
        {
            Result result;
            if (command == null)
            {
                return new Result(400, "Comando inválido", false);
            }
            try
            {
                var personDTO = new Application.Output.DTO.PersonDTO
                {
                    Id = command.Id,
                    Name = command.Name,
                    Email = command.Email,
                    BirthDate = command.DateOfBirth,
                    Status = command.Status,
                    Address = command.Address,
                    OtherInfos = command.OtherInfos
                };
                if (personDTO.IsDeleted == true)
                {
                    return new Result(400, "Esse registro está deletado", false);
                }
                result = (Result)_repository.UpdatePersonAsync(personDTO);
                return result;
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao atualizar registro: {ex.Message}", false);
            }
        }
    }
}
