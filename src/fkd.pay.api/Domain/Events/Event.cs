using System;
using MediatR;

namespace fkd.pay.api.Domain.Events
{
    public class Event : INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}