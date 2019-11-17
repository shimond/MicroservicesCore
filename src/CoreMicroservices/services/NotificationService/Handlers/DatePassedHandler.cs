using Infra.Messaging.Contract;
using Infra.Messaging.Model.Messages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Handlers
{
    class DatePassedHandler : IEventHandler<DatePassedEvent>
    {
        private ILogger<DatePassedHandler> _logger;

        public Task Handle(DatePassedEvent @event)
        {
            return Task.CompletedTask;
        }

        public Task Handle(object @event)
        {
            return Handle(@event as DatePassedEvent);
        }

        public DatePassedHandler(ILogger<DatePassedHandler> logger)
        {
            _logger = logger;
        }
    }
}
