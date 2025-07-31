using Application.Input.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class EmailValidateInDBCommand : ICommandBase
    {
        public required string Email { get; set; }
    }
}
