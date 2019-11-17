using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infra.Messaging.Contract;
using Infra.Messaging.Model.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TimeWorkerService
{
    public class TimeWorker : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<TimeWorker> _logger;
        private DateTime _lastCheck;

        public TimeWorker(ILogger<TimeWorker> logger, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.Now.Subtract(_lastCheck).Days > 0)
                {
                    _logger.LogInformation("Day has passed!");
                    _lastCheck = DateTime.Now;
                    DateTime passedDay = _lastCheck.AddDays(-1);
                    DatePassedEvent e = new DatePassedEvent();
                    await _eventBus.Publish(e);
                }
                Thread.Sleep(10000);
            }
        }
    }
}
