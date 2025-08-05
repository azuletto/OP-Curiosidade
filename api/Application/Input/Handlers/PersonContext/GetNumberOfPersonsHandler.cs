using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;

namespace Application.Input.Handlers.PersonContext
{
    public class GetNumberOfPersonsHandler
    {
        private readonly IPersonRepository _repository;
        public GetNumberOfPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle()
        {
            Result result;
            try
            {
                int numberOfPersons = _repository.GetNumberOfPersonsAsync().Result;
                result = new Result(200, "Número de pessoas obtido com sucesso", true);
                result.SetData(numberOfPersons);
                return result;
            }
            catch (Exception ex)
            {
                return result = new Result(500, $"Erro ao obter número de pessoas: {ex.Message}", false);
            }
        }
    }
}
