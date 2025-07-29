using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class DeletePersonCommand
    {
        public required Guid Id { get; set; }
    }
}
