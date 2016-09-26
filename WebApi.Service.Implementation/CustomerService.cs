using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region Sync Calls
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
        #endregion

        #region Async Calls
        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            var savedCustomer = await _customerRepository.SaveEntityAsync(customer);

            return savedCustomer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetEntitiesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteEntityAsync(id);
        }
        #endregion
    }
}
