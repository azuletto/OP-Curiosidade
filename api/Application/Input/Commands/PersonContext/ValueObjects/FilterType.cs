using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext.ValueObjects
{
    public class FilterType
    {
        public bool filterByName { get; set; } = false;
        public bool filterByTimeStamp { get; set; } = false;
        public bool filterByStatus { get; set; } = false;
        public bool filterByEmail { get; set; } = false;
    }
}
