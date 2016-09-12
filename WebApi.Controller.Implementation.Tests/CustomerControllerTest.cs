using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WebApi.Service.Interface;
using WebApi.Test.Data;

namespace WebApi.Controller.Implementation.Tests
{
    [TestFixture]
    public class CustomerControllerTest
    {
        private Mock<ICustomerService> _customerServiceMock;
        private CustomerController _customerController;

        [SetUp]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _customerController = new CustomerController(_customerServiceMock.Object);
        }

        [Test]
        public void Get_Customers()
        {
            // Arrange
            var actualCustomers = CustomerData.GetCustomers();
            _customerServiceMock.Setup(x => x.GetCustomers()).Returns(actualCustomers);

            // Act
            var expectedCustomers = _customerController.Get();

            // Assert
            expectedCustomers.ShouldBeEquivalentTo(actualCustomers);
        }

        [Test]
        public void Get_Customer_By_Id()
        {
            // Arrange
            const int id = 1;

            var actualCustomers = CustomerData.GetCustomers().ToList();

            var actualCustomer = actualCustomers.FirstOrDefault(x => x.Id == id);

            _customerServiceMock.Setup(x => x.GetCustomers()).Returns(actualCustomers);

            // Act
            var expectedCustomer = _customerController.Get(id);

            // Assert
            expectedCustomer.ShouldBeEquivalentTo(actualCustomer);
        }

        [Test]
        public void Save_Customer()
        {
            
        }
    }
}
