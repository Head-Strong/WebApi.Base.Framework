using System.Collections.Generic;
using WebApi.Domains;

namespace WebApi.Test.Data
{
    public class CustomerData
    {
        public static Customer GetCustomer()
        {
            var customer = new Customer
            {
                Name = "Aditya",
                LastName = "Magotra",
                Id = 1
            };

            return customer;
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer> {GetCustomer()};


            return customers;
        }
    }
}
