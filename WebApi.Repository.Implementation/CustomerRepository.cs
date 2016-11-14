using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        #region Sync methods
        public Customer SaveEntity(Customer entity)
        {
            var maxId = _customers.Max(x => x.Id);

            entity.Id = maxId + 1;

            _customers.Add(entity);

            return entity;
        }

        public Customer UpdateEntity(Customer entity)
        {
            var getEntity = GetEntities().FirstOrDefault(x => x.Id == entity.Id);

            if (getEntity == null)
            {
                throw new InvalidDataException();
            }

            getEntity.Name = entity.Name;
            getEntity.LastName = entity.LastName;

            return getEntity;
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
        #endregion

        #region Async Methods
        public async Task<Customer> SaveEntityAsync(Customer entity)
        {
            var maxId = await Task.Run(() => _customers.Max(x => x.Id));

            entity.Id = maxId + 1;

            _customers.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Customer>> GetEntitiesAsync()
        {
            return await Task.Run(() => _customers);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var allCustomers = await Task.Run(() => _customers);

            var customer = allCustomers.First(x => x.Id == id);

            _customers.Remove(customer);
        }

        public async Task<Customer> UpdateEntityAsync(Customer entity)
        {
            var getEntities = await GetEntitiesAsync();

            var getEntity = getEntities.FirstOrDefault(x => x.Id == entity.Id);

            if (getEntity == null)
            {
                throw new InvalidDataException();
            }

            getEntity.Name = entity.Name;
            getEntity.LastName = entity.LastName;

            return getEntity;
        }

        #endregion 

        #region Private Methods

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

        #endregion
    }
}
