using Application.Input.Commands.Interfaces;
using Application.Output.Results.Interfaces;

namespace Application.Input.Handlers.Interfaces
{
    public interface IHandlerBase<in T> where T : ICommandBase
    {
        IResultBase Handle(T command);
    }
}
