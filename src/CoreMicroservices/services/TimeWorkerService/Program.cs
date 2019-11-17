using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infra.Messaging.Contract;
using Infra.Messaging.Model.Configuration;
using Infra.Messaging.Services;
using Infra.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TimeWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(host => 
                host.AddJsonFile(Path.GetFullPath("../../rabbit-mq.json")))
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<EventBusConfiguration>(
                        hostContext.Configuration.GetSection("EventBus"));
                    
                    services.AddTransient<IMessageSerializer, JsonMessageSerializer>();
                    services.AddSingleton<IEventBus, RabbitEventBus>();
                    
                    services.AddHostedService<TimeWorker>();
                });
    }
}
