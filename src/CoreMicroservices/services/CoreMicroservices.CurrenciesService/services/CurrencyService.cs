using CoreMicroservices.CurrenciesService.model;
using CoreMicroservices.CurrenciesService.services.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreMicroservices.CurrenciesService.services
{
    
    public class CurrencyService : ICurrencyService
    {
        public List<Currency> GetAll()
        {
            XDocument doc = XDocument.Load("https://www.boi.org.il/currency.xml");
            var result = doc.Descendants("CURRENCY")
                .Select(c =>
            new Currency
            {
                Change = (double)c.Element("CHANGE"),
                Country = (string)c.Element("COUNTRY"),
                CurrencyCode = (string)c.Element("CURRENCYCODE"),
                Rate = (double)c.Element("RATE"),
                Name = (string)c.Element("NAME")
            }).ToList();
            return result;
        }

        public Currency GetByCode(string code)
        {
            return this.GetAll().FirstOrDefault(x => x.CurrencyCode == code);
        }




    }
}
