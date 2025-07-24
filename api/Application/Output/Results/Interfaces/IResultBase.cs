using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
