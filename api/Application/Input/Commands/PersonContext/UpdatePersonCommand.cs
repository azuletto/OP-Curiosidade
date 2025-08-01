using Application.Output.DTO;

namespace Application.Input.Commands.PersonContext
{
    public class UpdatePersonCommand
    {
        public required PersonViewDataDTO personViewDataDTO { get; set; }
    }
}
