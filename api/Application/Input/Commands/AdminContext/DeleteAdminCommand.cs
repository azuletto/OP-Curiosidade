using Application.Input.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.AdminContext
{
    public class DeleteAdminCommand : ICommandBase
    {
        public required Guid Id { get; set; }
    }
}
