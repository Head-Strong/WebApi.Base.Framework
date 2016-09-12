using System.Collections.Generic;
using WebApi.Domains;

namespace WebApi.Service.Interface
{
    public interface ICustomerService
    {
        Customer SaveCustomer(Customer customer);

        IEnumerable<Customer> GetCustomers();

        void DeleteCustomer(int id);
    }
}
