using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Controller.Interface;
using WebApi.Domains;
using WebApi.Service.Interface;

namespace WebApi.Controller.Implementation
{
    public class CustomerController : ApiController, ICustomerController
    {
        private readonly ICustomerService _customerService;

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
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        /// <summary>
        /// Get Customer By Id.
        /// </summary>
        /// <param name="id">Customer Id, Type Int</param>
        /// <returns>Customer</returns>
        public Customer Get(int id)
        {
            return _customerService.GetCustomers().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Save customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Customer Details After Save</returns>
        [HttpPost]
        public Customer Post(Customer customer)
        {
            _customerService.SaveCustomer(customer);

            return customer;
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        [HttpPost]
        public void Delete([FromBody]int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
