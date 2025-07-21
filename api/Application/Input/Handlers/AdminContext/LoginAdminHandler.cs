using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Mapper;
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
    public class LoginAdminHandler : IHandlerBase<LoginAdminCommand>
    {
        AdminMapper adminMapper = new();
        private readonly IAdminRepository _repository;
        public LoginAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(LoginAdminCommand command)
        {
            Result result;
            var admin = _repository.GetAdminByEmailAsync(command.Email);
            if (admin != null)
            {
                var adminDTO = adminMapper.MapToDTO(admin);
                var isValidPassword = _repository.CheckPasswordAsync(adminDTO, command.Password);
                if (isValidPassword.IsOk)
                {
                    result = new Result(200, "Login realizado com sucesso", true);
                    result.SetData(adminDTO);
                    return result;
                }
                else
                {
                    return new Result(401, "Senha incorreta", false);
                }
            }
            else
            {
                return new Result(404, "Admin não encontrado", false);
            }
        }
    }
}
