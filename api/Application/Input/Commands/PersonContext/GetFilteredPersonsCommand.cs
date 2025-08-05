using Application.Input.Commands.Interfaces;
using Application.Input.Commands.PersonContext.ValueObjects;

namespace Application.Input.Commands.PersonContext
{
    public class GetFilteredPersonsCommand : ICommandBase
    {
        public required FilterType filterType { get; set; }
        public bool inDashboard { get; set; } = false;

        public int filterStatus { get; set; } = 0;
    }
}
