using Application.Input.Commands.Interfaces;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class InsertPersonCommand : ICommandBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required bool Status { get; set; } = true;
        public required string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; } = null;
    }
}
