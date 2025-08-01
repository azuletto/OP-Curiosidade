using Application.Input.Commands.PersonContext;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.PersonContext;

namespace Application.Input.Handlers.PersonContext
{
    public class UpdatePersonHandler
    {
        private readonly IPersonRepository _repository;
        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(UpdatePersonCommand command)
        {
            Result result;
            if (command == null)
            {
                return new Result(400, "Comando inválido", false);
            }
            try
            {
                result = (Result)_repository.UpdatePersonAsync(command.personViewDataDTO);
                if (result.IsOk)
                {
                    return result;
                }
                else
                {
                    return new Result(400, "Erro ao atualizar pessoa", false);
                }
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro ao atualizar registro: {ex.Message}", false);
            }
        }
    }
}
