using Application.Output.Results.Interfaces;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Output.Results
{
    public class Result : IResultBase
    {
        private List<Notification> _notifications;

        public Result(int resultCode, string message, bool isOk)
        {
            ResultCode = resultCode;
            Message = message;
            IsOk = isOk;
            _notifications = new List<Notification>();  
        }
        public int ResultCode { get; private set; }
        public string Message { get; private set; }
        public bool IsOk { get; set; }
        public object? Data { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public void SetNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
        }
        public void SetData(object data)
        {
            Data = data;
        }
    }
}
