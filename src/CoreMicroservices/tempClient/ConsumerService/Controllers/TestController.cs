using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;

namespace ConsumerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("CURRRENCY");
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await RestService.For<ICurrencyAPI>(this._httpClient).GetAll();
            return Ok(result);
        }
    }
}
