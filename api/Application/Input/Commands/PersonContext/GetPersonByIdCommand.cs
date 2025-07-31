using Application.Input.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class GetPersonByIdCommand : ICommandBase
    {
        required public Guid Id { get; set; }
    }
}
