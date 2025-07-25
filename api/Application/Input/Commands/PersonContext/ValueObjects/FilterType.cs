using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Commands.PersonContext.ValueObjects
{
    public class FilterType
    {
        public bool filterByName { get; set; }
        public bool filterByTimeStamp { get; set; }
        public bool filterByStatus { get; set; }
        public bool filterByEmail { get; set; }
    }
}
