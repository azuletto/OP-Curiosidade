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
    public class SearchPersonsHandler
    {
        private readonly IPersonRepository _repository;
        public SearchPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(string searchTerm)
        {
            try
            {
                var persons = _repository.GetPersonByNameAsync(searchTerm).Result;
                if (persons == null || !persons.Persons.Any())
                {
                    var parsons = _repository.GetPersonByEmailAsync(searchTerm).Result;
                } else if (persons == null || !persons.Persons.Any())
                {
                    return new Result(404, "Nenhuma pessoa encontrada com o termo de pesquisa fornecido", false);
                }
                Result result = persons.Result;
                result.SetData(persons.Persons.ToList());
                return result;
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao buscar pessoas: {ex.Message}", false);
            }
        }
    }
}
