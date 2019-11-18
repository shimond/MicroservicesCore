using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using Steeltoe.Common.Discovery;

namespace ConsumerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TestController> _logger;
        private readonly DiscoveryHttpClientHandler _handler;

        public TestController(ILogger<TestController> logger, IHttpClientFactory clientFactory, IDiscoveryClient discoveryClient)
        {
            _httpClient = clientFactory.CreateClient("CURRRENCY");
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(discoveryClient);
        }

         
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await RestService.For<ICurrencyAPI>(this._httpClient).GetAll();
            return Ok(result);
        }

        [HttpGet("discovery")]
        public async Task<string> UseDiscovery()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync("http://CoreMicroservices-CurrenciesService/currencies");
        }
    }
}
