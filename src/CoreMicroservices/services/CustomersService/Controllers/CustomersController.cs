using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomersService.Model;
using CustomersService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomersService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomersRepository _customersRepository;

        [HttpGet]
        public ActionResult<Customer[]> GetAll()
        {
            return Ok( _customersRepository.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }




    }
}