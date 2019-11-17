using System.Threading.Tasks;
using CustomersService.Model;

namespace CustomersService.Services
{
    public interface ICustomersRepository
    {

        Task<Customer> AddNewCustomer(Customer c);
        Customer GetCustomerById(int id);
        Customer[] GetAll();

    }
}