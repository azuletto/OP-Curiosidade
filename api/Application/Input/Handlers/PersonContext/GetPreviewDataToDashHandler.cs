using Application.Input.Commands.PersonContext;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;

namespace Application.Input.Handlers.PersonContext
{
    public class GetPreviewDataToDashHandler
    {
        private readonly IPersonRepository _repository;
        public GetPreviewDataToDashHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(TablePaginationCommand command)
        {
            Result result;
            try
            {
                var previewData = _repository.GetPreviewDataToDashAsync
                    (
                    command.skipTable, 
                    command.filterStatus, 
                    command.filterType
                    )
                    .Result;
                result = new Result(200, "Dados de pré-visualização obtidos com sucesso", true);
                result.SetData(previewData);
            }
            catch (Exception ex)
            {
                result = new Result(500, $"Erro ao obter dados de pré-visualização: {ex.Message}", false);
            }
            return result;
        }
    }
}
