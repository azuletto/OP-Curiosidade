using OpCuriosidade.Entities.PersonnelContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Output.DTO
{
    public struct PersonDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public DateOnly BirthDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public OtherInfos? OtherInfos { get; set; }
    }
}
