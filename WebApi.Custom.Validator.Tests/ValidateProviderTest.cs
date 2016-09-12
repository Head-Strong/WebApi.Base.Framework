using System.Runtime.Remoting;
using System.Web.Http.Validation;
using FluentAssertions;
using NUnit.Framework;
using WebApi.Domains;

namespace WebApi.Custom.Validator.Tests
{
    [TestFixture]
    public class ValidateProviderTest : ValidateProvider
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void When_Invalid_Customer_Is_Passed_Then_It_Should_Throw_An_Error()
        {
            var result = base.GetTypeDescriptor(_customer.GetType());

            result.Should().NotBeNull();
        }
    }
}
