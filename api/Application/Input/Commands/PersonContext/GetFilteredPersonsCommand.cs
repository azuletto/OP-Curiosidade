using Application.Input.Commands.Interfaces;
using Application.Input.Commands.PersonContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class GetFilteredPersonsCommand : ICommandBase
    {
        public required FilterType filterType { get; set; }
        public bool inDashboard { get; set; } = false;
    }
}
