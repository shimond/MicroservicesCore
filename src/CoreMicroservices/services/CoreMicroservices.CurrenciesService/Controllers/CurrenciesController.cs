using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMicroservices.CurrenciesService.model;
using CoreMicroservices.CurrenciesService.services.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreMicroservices.CurrenciesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<CurrenciesController> _logger;

        public CurrenciesController(ILogger<CurrenciesController> logger,  ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            _logger = logger;
        }


        [HttpGet]
        public ActionResult<List<Currency>> Get()
        {
            _logger.LogInformation("INFO");
            _logger.LogWarning("WARNING");
            _logger.LogError( new DivideByZeroException(),  "ERROR");
            _logger.LogDebug("DEBUG");
            return Ok(_currencyService.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{code}")]
        public ActionResult<Currency> GetByCode(string code)
        {
            var currency = _currencyService.GetByCode(code);
            if (currency != null)
            {
                return Ok(currency);
            }

            return NotFound();
        }
    }
}
