using CoreMicroservices.CurrenciesService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMicroservices.CurrenciesService.services.contracts
{
    public interface ICurrencyService
    {
        List<Currency> GetAll();
        Currency GetByCode(string code);
    }
}
