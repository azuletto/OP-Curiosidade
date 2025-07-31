using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;

namespace Application.Input.Handlers.PersonContext
{
    public class GetNumberOfPendingPersonsHandler
    {
        private readonly IPersonRepository _repository;
        public GetNumberOfPendingPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle()
        {
            Result result;
            try
            {
                int numberOfPendingPersons = _repository.GetNumberOfPendingPersonsAsync().Result;
                result = new Result(200, "Número de pessoas pendentes obtido com sucesso", true);
                result.SetData(numberOfPendingPersons);
                return result;
            }
            catch (Exception ex)
            {
                return result = new Result(500, $"Erro ao obter número de pessoas pendentes: {ex.Message}", false);
            }
        }
    }
}
