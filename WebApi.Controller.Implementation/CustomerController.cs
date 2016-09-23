using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
            return customers.Select(x => CustomerTranslator.Translate(x));
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
        public CustomerDto Post(Customer customer)
        {
            _customerService.SaveCustomer(customer);

            return CustomerTranslator.Translate(customer);
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
