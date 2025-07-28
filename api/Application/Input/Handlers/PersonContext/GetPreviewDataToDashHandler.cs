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
    public class GetPreviewDataToDashHandler
    {
        private readonly IPersonRepository _repository;
        public GetPreviewDataToDashHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle()
        {
            Result result;
            try
            {
                var previewData = _repository.GetPreviewDataToDashAsync().Result;
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
