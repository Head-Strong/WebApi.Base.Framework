using FluentAssertions;
using Moq;
using NUnit.Framework;
using WebApi.Domains;
using WebApi.Repository.Interface;
using WebApi.Service.Interface;
using WebApi.Test.Data;

namespace WebApi.Service.Implementation.Test
{
    [TestFixture]
    public class CustomerServiceTest
    {
        private ICustomerService _customerService;
        private Mock<IRepository<Customer>> _customerMockRepository;

        [SetUp]
        public void Setup()
        {
            _customerMockRepository = new Mock<IRepository<Customer>>();
            _customerService = new CustomerService(_customerMockRepository.Object);
        }

        [Test]
        public void Save_Customer()
        {
            // Arrange
            var actualCustomer = CustomerData.GetCustomer();
            _customerMockRepository.Setup(x => x.SaveEntity(actualCustomer)).Returns(actualCustomer);

            // Act
            var expectedCustomer = _customerService.SaveCustomer(actualCustomer);

            // Assert
            expectedCustomer.ShouldBeEquivalentTo(actualCustomer);
        }

        [Test]
        public void Get_Customers()
        {
            // Arrange
            var actualCustomers = CustomerData.GetCustomers();
            _customerMockRepository.Setup(x => x.GetEntities()).Returns(actualCustomers);

            // Act
            var expectedCustomers = _customerService.GetCustomers();

            // Assert
            expectedCustomers.ShouldBeEquivalentTo(actualCustomers);
        }
    }
}
