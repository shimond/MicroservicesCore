using CustomersService.Context;
using CustomersService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersService.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private CustomerContext _customerContext;

        public async Task<Customer> AddNewCustomer(Customer c)
        {
            _customerContext.Add(c);
            await _customerContext.SaveChangesAsync();
            return c;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerContext.Customers.FirstOrDefault(x => x.ID == id);
        }

        public Customer[] GetAll()
        {
            return _customerContext.Customers.ToArray();
        }

        public CustomersRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
    }
}
