using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using WebApi.Domains;
using WebApi.Repository.Interface;
using WebApi.Test.Data;

namespace WebApi.Repository.Implementation.Test
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        private IRepository<Customer> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CustomerRepository();
        }

        [Test]
        public void Get_All_Customers()
        {
            var customers = _repository.GetEntities();

            customers.Should().NotBeNull();

            customers.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void SaveCustomer()
        {
            var customerEntity = CustomerData.GetCustomer();

            var customer = _repository.SaveEntity(customerEntity);

            customer.Id.Should().BeGreaterThan(0);
        }        
    }
}
