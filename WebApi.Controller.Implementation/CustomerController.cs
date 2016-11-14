using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApi.Controller.Implementation.Translator;
using WebApi.Controller.Interface;
using WebApi.Domains;
using WebApi.Dto;
using WebApi.Service.Interface;

namespace WebApi.Controller.Implementation
{
    public class CustomerController : ApiController, ICustomerController
    {
        private readonly ICustomerService _customerService;

        #region Synchronize Calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public IEnumerable<CustomerDto> Get()
        {
            var customers = _customerService.GetCustomers();
            return customers.Select(CustomerTranslator.Translate);
        }

        ///// <summary>
        ///// Get Customer By Id.
        ///// </summary>
        ///// <param name="id">Customer Id, Type Int</param>
        ///// <returns>Customer</returns>
        public CustomerDto Get(int id)
        {
            var customer = _customerService.GetCustomers().FirstOrDefault(x => x.Id == id);
            return CustomerTranslator.Translate(customer);
        }

        /// <summary>
        /// Save customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Customer Details After Save</returns>
        [HttpPost]
        public CustomerDto Post([ModelBinder]Customer customer)
        {
            _customerService.SaveCustomer(customer);

            return CustomerTranslator.Translate(customer);
        }

        /// <summary>
        /// CustomerDelete Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        public void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public CustomerDto Put([ModelBinder]Customer customer)
        {
            customer = _customerService.UpdateCustomer(customer);

            return CustomerTranslator.Translate(customer);
        }

        #endregion

        #region Asynchronize Calls
        /// <summary>
        /// Get Customers Async
        /// </summary>
        /// <returns>Return Customers</returns>
        [Route("api/customer/async")]
        public async Task<IEnumerable<CustomerDto>> GetAsync()
        {
            var customers = await _customerService.GetCustomersAsync();
            return customers.Select(CustomerTranslator.Translate);
        }

        /// <summary>
        /// Get Customer ById Async
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        [Route("api/customer/async/{id}")]
        public async Task<CustomerDto> GetAsync(int id)
        {
            var customerResult = await _customerService.GetCustomersAsync();

            var customer = customerResult.FirstOrDefault(x => x.Id == id);

            return CustomerTranslator.Translate(customer);
        }

        /// <summary>
        /// Save Customer Async
        /// </summary>
        /// <param name="customer">Customer Details</param>
        /// <returns>Customer Saved and Customer Object Has Id</returns>
        [HttpPost]
        [Route("api/customer/async")]
        public async Task<CustomerDto> PostAsync([ModelBinder]Customer customer)
        {
            await _customerService.SaveCustomerAsync(customer);

            return CustomerTranslator.Translate(customer);
        }

        /// <summary>
        /// CustomerDelete Customer Async By Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        [Route("api/customer/async/{id}")]
        public async Task DeleteAsync(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
        }

        [Route("api/customer/async")]
        public async Task<CustomerDto> PutAsync(Customer customer)
        {
            customer = await _customerService.UpdateCustomerAsync(customer);

            return CustomerTranslator.Translate(customer);
        }

        #endregion
    }
}
