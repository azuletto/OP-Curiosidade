using Application.Input.Commands.Interfaces;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.AdminContext
{
    public class InsertAdminCommand : ICommandBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}