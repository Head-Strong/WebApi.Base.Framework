using System.Collections.Generic;
using System.Linq;
using WebApi.Domains;
using WebApi.Repository.Interface;

namespace WebApi.Repository.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        private static List<Customer> _customers;

        public CustomerRepository()
        {
            if (_customers == null)
            {
                _customers = GetCustomers().ToList();
            }
        }

        public Customer SaveEntity(Customer entity)
        {
            var maxId = _customers.Max(x => x.Id);

            entity.Id = maxId + 1;

            _customers.Add(entity);

            return entity;
        }

        public IEnumerable<Customer> GetEntities()
        {
            return _customers;
        }

        public void DeleteEntity(int id)
        {
            var customer = _customers.First(x => x.Id == id);

            _customers.Remove(customer);
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    Id=1,
                    Name = "Aditya",
                    LastName = "Magotra"
                },
                new Customer
                {
                    Id = 2,
                    LastName = "Last",
                    Name = "First"
                },
                new Customer
                {
                    Id = 3,
                    LastName = "ABC",
                    Name = "DEF"
                },
                new Customer
                {
                    Id = 4,
                    LastName = "GHI",
                    Name = "JKL"
                },
                new Customer
                {
                    Id = 5,
                    LastName = "MNO",
                    Name = "PQR"
                }

            };

            return _customers;
        }
    }
}
