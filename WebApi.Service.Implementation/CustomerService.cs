using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;
using WebApi.Domains;
using WebApi.Repository.Interface;
using WebApi.Service.Interface;

namespace WebApi.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public Customer SaveCustomer(Customer customer)
        {
            var savedCustomer = _customerRepository.SaveEntity(customer);

            return savedCustomer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetEntities();
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteEntity(id);
        }
    }
}
