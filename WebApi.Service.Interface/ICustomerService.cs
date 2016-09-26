using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domains;

namespace WebApi.Service.Interface
{
    public interface ICustomerService
    {
        Customer SaveCustomer(Customer customer);

        IEnumerable<Customer> GetCustomers();

        void DeleteCustomer(int id);

        Task<Customer> SaveCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task DeleteCustomerAsync(int id);
    }
}
