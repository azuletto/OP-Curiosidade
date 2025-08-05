using Application.Input.Commands.Interfaces;

namespace Application.Input.Commands.PersonContext
{
    public class TablePaginationCommand : ICommandBase
    {
        public required int SkipTable { get; set; }
    }
}
