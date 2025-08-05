using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.PersonContext
{
    public class EmailValidateInDBCommand : ICommandBase
    {
        public required string Email { get; set; }
    }
}
