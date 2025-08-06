using Application.Input.Commands.Interfaces;
using Application.Input.Commands.PersonContext.ValueObjects;

namespace Application.Input.Commands.PersonContext
{
    public class TablePaginationCommand : ICommandBase
    {
        public required int skipTable { get; set; }
        public required int filterStatus { get; set; }
        public required FilterType filterType { get; set; }
    }
}
