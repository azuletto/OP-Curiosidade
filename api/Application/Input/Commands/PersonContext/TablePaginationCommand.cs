using Application.Input.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class TablePaginationCommand : ICommandBase
    {
        public required int SkipTable { get; set; }
    }
}
