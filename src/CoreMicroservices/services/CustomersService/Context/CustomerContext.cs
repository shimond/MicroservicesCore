using CustomersService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersService.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) :
            base(options)
        {

            for (int i = 1; i < 20; i++)
            {
                Customer c = new Customer
                {
                    Birthdate = DateTime.Now.AddDays(-1 * i),
                    Email = $"customer{i}@gmail.com",
                    Name = $"Customer NO.{i}"
                };

                this.Customers.Add(c);
            }

            this.SaveChanges();


        }
        public DbSet<Customer> Customers { get; set; }
    }
}
