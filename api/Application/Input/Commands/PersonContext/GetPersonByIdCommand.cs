using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.PersonContext
{
    public class GetPersonByIdCommand : ICommandBase
    {
        required public Guid Id { get; set; }
    }
}
