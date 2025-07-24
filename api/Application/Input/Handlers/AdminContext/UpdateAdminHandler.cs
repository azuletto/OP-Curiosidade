using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.AdminContext
{
    public class UpdateAdminHandler : IHandlerBase<UpdateAdminCommand>
    {
        private readonly IAdminRepository _repository;
        public UpdateAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(UpdateAdminCommand command)
        {
            Result result;
            if (command == null)
            {
                return new Result(400, "Comando inválido", false);
            }
            try
            {
                var adminDTO = new Application.Output.DTO.AdminDTO
                {
                    Id = command.Id,
                    Name = command.Name,
                    Email = command.Email,
                    Password = command.Password,
                    IsDeleted = command.IsDeleted
                };
                if (adminDTO.IsDeleted == true)
                {
                    return new Result(400, "Admin já está deletado", false);
                }
                result = (Result)_repository.UpdateAdminAsync(adminDTO);
                return result;
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao atualizar admin: {ex.Message}", false);
            }
        }
    }
}
