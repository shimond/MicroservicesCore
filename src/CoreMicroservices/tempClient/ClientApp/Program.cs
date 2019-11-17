using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var relativePath = @"../../services-url.json";
            var absolutePath = System.IO.Path.GetFullPath(relativePath);

            return Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(p => p.AddJsonFile(absolutePath))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
        }

    }
}
