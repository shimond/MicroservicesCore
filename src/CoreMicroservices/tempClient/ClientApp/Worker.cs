using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ClientApp
{
    public class Worker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger,IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public async Task PrintCurrencyDataFromService(string code)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{_configuration["services:currencies"]}/{code}";
                var response = await client.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Enter currency code:");
                string code = Console.ReadLine();
                await this.PrintCurrencyDataFromService(code);
            }
        }
    }
}
