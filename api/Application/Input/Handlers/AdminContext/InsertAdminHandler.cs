using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.AdminContext
{
    public class InsertAdminHandler : IHandlerBase<InsertAdminCommand>
    {
        private readonly IAdminRepository _repository;
        public InsertAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(InsertAdminCommand command)
        {
            var admin = new Admin(command.Name,command.Email,command.IsDeleted,command.Password);
            Result result;
            if (admin.Validation())
            {
                try
                {
                    result = (Result)_repository.InsertAdmin(admin);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Erro ao inserir admin: {ex.Message}",false);
                    return result;
                }
            }
            result = new Result(400,"", false);
            var contracts = admin.Validation(true);
            result.SetNotifications(contracts.GetNotifications());
            return result;
        }
    }
}
