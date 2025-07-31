using Application.Output.DTO;

namespace Application.Input.Commands.PersonContext
{
    public class UpdatePersonCommand
    {
        public required PersonDTO personDTO { get; set; }
    }
}
