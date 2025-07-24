using Application.Input.Commands.PersonContext;
using Application.Input.Commands.PersonContext.ValueObjects;
using Application.Input.Handlers.Interfaces;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (command)
            {
                case null:
                    return null;
                case { filterType.filterByTimeStamp : true }:
                    // Handle filtering by age
                    return null;
                case { filterType.filterByEmail : true }:
                    // Handle filtering by email
                    return null;
                case { filterType.filterByName : true }:
                    // Handle filtering by name
                    return null;
                case { filterType.filterByStatus : true }:
                    // Handle filtering by status
                    return null;
                case { inDashboard: true }:
                    // Handle filtering in dashboard
                    return null;
            }

            throw new NotImplementedException();
        }
    }
}
