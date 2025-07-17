using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.DTO;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.AdminContext
{
    public class DeleteAdminHandler : IHandlerBase<DeleteAdminCommand>
    {
        private readonly IAdminRepository _repository;
        public DeleteAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(DeleteAdminCommand command)
        {
            Result result;
            AdminDTO deleteAdminDTO = new()
            {
                Id = command.Id
            };
            if (deleteAdminDTO.IsDeleted == true)
            {
                result = new Result(400, "Admin já está deletado", false);
                
                return result;
            }
            try
            {
                result = (Result)_repository.DeleteAdminByIdAsync(deleteAdminDTO.Id.Value);
                return result;
            }
            catch (Exception ex)
            {
                return result = new Result(500, $"Erro ao deletar admin: {ex.Message}", false);
            }
        }
    }
}
