using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext
{
    public class SearchPersonsCommand
    {
        required public string SearchTerm { get; set; }
    }
}
