using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CurrencyApiLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ClientApp
{
    public class Worker : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task PrintCurrencyDataFromService(string code)
        {
            try
            {
                var client = HttpClientFactory.Create();
                client.BaseAddress = new Uri($"{_configuration["services:currencies"]}");
                var typesClient = Refit.RestService.For<ICurrencyAPI>(client);
                var currency = await typesClient.GetById(code);
                Console.WriteLine(JsonConvert.SerializeObject(currency));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
