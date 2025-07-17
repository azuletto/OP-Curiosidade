using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.AdminContext
{
    public class GetAdminHandler : IHandlerBase<GetAdminCommand>
    {
        private readonly IAdminRepository _repository;
        public GetAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(GetAdminCommand command)
        {
            Result result;
            if (command.Id != null) {
                try
                {
                    var admin = _repository.GetAdminByIdAsync(command.Id.Value);
                    result = new Result(200, "Admin encontrado com sucesso", true);
                    result.SetData(admin);
                    return result;
                }
                catch (Exception ex)
                {
                    return new Result(404, $"Erro ao buscar admin: {ex.Message}", false);
                }
            }
            if (command.Name != null) {
                try
                {
                    var admin = _repository.GetAdminByNameAsync(command.Name);
                    result = new Result(200, "Admin encontrado com sucesso", true);
                    result.SetData(admin);
                    return result;
                }
                catch (Exception ex)
                {
                    return new Result(404, $"Erro ao buscar admin: {ex.Message}", false);
                }
            }
            if (command.Email != null) {
                try
                {
                    var admin = _repository.GetAdminByEmailAsync(command.Email);
                    result = new Result(200, "Admin encontrado com sucesso", true);
                    result.SetData(admin);
                    return result;
                }
                catch (Exception ex)
                {
                    return new Result(404, $"Erro ao buscar admin: {ex.Message}", false);
                }
            }
            else
            {
                return new Result(400, "Nenhum critério de busca fornecido", false);
            }
        }
    }
}
