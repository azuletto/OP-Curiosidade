using Application.Input.Commands.PersonContext;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;

namespace Application.Input.Handlers.PersonContext
{
    public class GetFilteredPersonsHandler : IHandlerBase<GetFilteredPersonsCommand>
    {
        private readonly IPersonRepository _repository;
        public GetFilteredPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(GetFilteredPersonsCommand command)
        {


            throw new NotImplementedException();
        }
    }
}
