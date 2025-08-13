using OpCuriosidade.Notifications;

namespace Application.Output.Results.Interfaces
{
    public interface IResultBase
    {
        int ResultCode { get; }
        string Message { get; }
        bool IsOk { get; }
        object? Data { get; }
        IReadOnlyCollection<Notification> Notifications { get; }
    }
}
