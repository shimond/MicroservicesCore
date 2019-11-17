using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infra.Messaging.Contract;
using Infra.Messaging.Model.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Handlers;

namespace NotificationService
{
    public class NotificationWorker : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<NotificationWorker> _logger;

        public NotificationWorker(ILogger<NotificationWorker> logger, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _logger = logger;
            InitSubscriptions();    
        }

        private void InitSubscriptions()
        {
            _eventBus.Subscribe<DatePassedEvent, IEventHandler<DatePassedEvent>>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
