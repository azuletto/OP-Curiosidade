using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.AdminContext
{
    public class InsertAdminCommand : ICommandBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}