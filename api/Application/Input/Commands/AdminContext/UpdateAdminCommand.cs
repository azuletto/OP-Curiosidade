using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.AdminContext
{
    public class UpdateAdminCommand : ICommandBase
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
