﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersService.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
