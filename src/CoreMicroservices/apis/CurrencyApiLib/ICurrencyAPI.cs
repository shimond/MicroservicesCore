using CurrencyApiLib.model;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyApiLib
{
    public interface ICurrencyAPI
    {
        [Get("/currencies")]
        Task<List<CurrencyDTO>> GetAll();
        [Get("/currencies/{currencyCode}")]
        Task<CurrencyDTO> GetById(string currencyCode);
    }
}
