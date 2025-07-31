using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.AdminContext
{
    public class LoginAdminCommand : ICommandBase
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
