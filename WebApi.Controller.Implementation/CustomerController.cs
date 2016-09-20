using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApi.Controller.Interface;
using WebApi.Domains;
using WebApi.Dto;
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
        public IEnumerable<CustomerDto> Get()
        {
            var customers = _customerService.GetCustomers();
            return customers.Select(x => (CustomerDto)x);
        }

        ///// <summary>
        ///// Get Customer By Id.
        ///// </summary>
        ///// <param name="id">Customer Id, Type Int</param>
        ///// <returns>Customer</returns>
        public CustomerDto Get(int id)
        {
            var customer = _customerService.GetCustomers().FirstOrDefault(x => x.Id == id);
            return customer;
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

            return customer;
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        //[HttpDelete]
        public void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
