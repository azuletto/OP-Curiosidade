using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Output.DTO
{
    public struct AdminDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string Password { get; private set; }
    }
}
