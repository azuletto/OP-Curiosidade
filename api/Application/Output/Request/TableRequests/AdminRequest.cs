using Application.Output.DTO;
using Application.Output.Request.Interfaces;
using Application.Output.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Output.Request.TableRequests
{
    public class AdminRequest : IRequestBase
    {
        public required Result Result { get; set; }
        public AdminDTO Admin { get; set; }
        public required IEnumerable<PersonDTO> Persons { get; set; }
    }
}
