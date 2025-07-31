using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class UpdatePersonCommand
    {
        public required PersonDTO personDTO { get; set; }
    }
}
