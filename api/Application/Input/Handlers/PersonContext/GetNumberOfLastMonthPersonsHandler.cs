using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.AdminContext;
using Application.Repositories.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Input.Handlers.PersonContext
{
    public class GetNumberOfLastMonthPersonsHandler
    {
        private readonly IPersonRepository _repository;
        public GetNumberOfLastMonthPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle()
        {
            Result result;
            try
            {
                int numberOfLastMonthPersons = _repository.GetNumberOfLastMonthPersonsAsync().Result;
                result = new Result(200, "Número de pessoas do último mês obtido com sucesso", true);
                result.SetData(numberOfLastMonthPersons);
                return result;
            }
            catch (Exception ex)
            {
                return result = new Result(500, $"Erro ao obter número de pessoas do último mês: {ex.Message}", false);
            }
        }
    }
}
