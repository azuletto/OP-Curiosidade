using Application.Input.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.AdminContext
{
    public class GetAdminCommand : ICommandBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? Id { get; set; }
    }
}
