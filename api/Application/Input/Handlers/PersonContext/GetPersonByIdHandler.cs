using Application.Output.DTO;
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
    public class GetPersonByIdHandler
    {
        private readonly IPersonRepository _repository;
        public GetPersonByIdHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(Guid id)
        {
            try
            {
                var person = _repository.GetPersonByIdAsync(id).Result;
                if (person.Equals(default(PersonDTO)))
                {
                    return new Result(404, "Pessoa não encontrada", false);
                }
                var result = new Result(200, "Pessoa obtida com sucesso", true);
                result.SetData(person);
                return result;
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao obter pessoa: {ex.Message}", false);
            }
        }
    }
}
