using Application.Input.Commands.PersonContext;
using Application.Input.Handlers.Interfaces;
using Application.Mapper;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.PersonContext
{
    public class GetAllPersonsHandler : IHandlerBase<GetAllPersonsCommand>
    {
        private readonly IPersonRepository _repository;
        public GetAllPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(GetAllPersonsCommand command)
        {
            if (command == null)
            {
                return new Result(400, "Comando inválido", false);
            }
            try
            {
                var adminRequest = _repository.GetAllPersonsAsync().Result;
                if (adminRequest == null || adminRequest.Persons == null || !adminRequest.Persons.Any())
                {
                    return new Result(404, "Nenhuma pessoa encontrada", false);
                }
                Result result = adminRequest.Result;
                result.SetData(PersonTableViewMapper.MapToTableView(adminRequest.Persons.ToList()));
                return result;
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao buscar pessoas: {ex.Message}", false);
            }
        }
    }
}
