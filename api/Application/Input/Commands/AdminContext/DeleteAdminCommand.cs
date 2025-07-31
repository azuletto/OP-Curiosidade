using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.AdminContext
{
    public class DeleteAdminCommand : ICommandBase
    {
        public required Guid Id { get; set; }
    }
}
