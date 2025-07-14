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

        public Result()
        {

        }
    }
}
