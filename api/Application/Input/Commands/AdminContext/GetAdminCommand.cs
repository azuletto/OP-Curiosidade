using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.AdminContext
{
    public class GetAdminCommand : ICommandBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? Id { get; set; }
    }
}
