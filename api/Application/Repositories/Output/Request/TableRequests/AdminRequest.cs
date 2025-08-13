using Application.Output.DTO;
using Application.Output.Request.Interfaces;
using Application.Output.Results;

namespace Application.Output.Request.TableRequests
{
    public class AdminRequest : IRequestBase
    {
        public required Result Result { get; set; }
        public required IEnumerable<PersonTableViewDTO>? Persons { get; set; }
    }
}
