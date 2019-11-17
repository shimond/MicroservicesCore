using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApiLib.model
{
    public class CurrencyDTO
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string CurrencyCode { get; set; }
        public double Change { get; set; }
        public string Country { get; set; }
    }
}
