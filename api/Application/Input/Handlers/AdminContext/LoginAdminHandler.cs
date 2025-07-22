using Application.Auth;
using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.Interfaces;
using Application.Mapper;
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
    public class LoginAdminHandler : IHandlerBase<LoginAdminCommand>
    {
        private readonly AuthService _authService = new();
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
                    var token = _authService.GenerateToken(adminDTO );
                    result = new Result(200, "Login realizado com sucesso", true);
                    var data = new
                    {
                        Token = token,
                        Admin = adminDTO
                    };
                    result.SetData(adminDTO);
                    return result;
                }
                else
                {
                    result = new Result(401, "Credenciais inválidas", false);
                    Notification notification = new Notification("Email ou senha incorretos.", "invalidCredentials");
                    result.SetNotifications(new List<Notification> { notification });
                    return result;
                }
            }
            else
            {
                result = new Result(401, "Credenciais inválidas", false);
                Notification notification = new Notification("Email ou senha incorretos.", "invalidCredentials");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
        }
    }
}
