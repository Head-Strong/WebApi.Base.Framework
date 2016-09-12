using System.Linq;
using FluentAssertions;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using WebApi.Domains;
using WebApi.Repository.Interface;
using WebApi.Service.Interface;

namespace WebApi.Custom.Unity.Test
{
    [TestFixture]
    public class UnityRegisterTest
    {
        private IUnityContainer _unityContainer;

        [Test]
        public void Check_Services_Register()
        {
            // Act
            _unityContainer = new UnityRegister().RegisterServices();

            // Assert
            _unityContainer.Should().NotBeNull();

            CheckFullName(typeof(ICustomerService).FullName);            
        }

        [Test]
        public void Check_Repository_Register()
        {
            // Act
            _unityContainer = new UnityRegister(new UnityContainer()).RegisterRepository();

            // Assert
            _unityContainer.Should().NotBeNull();

            CheckFullName(typeof(IRepository<Customer>).FullName);
        }

        [Test]
        public void Check_Registration_Of_Methods()
        {
            // Act
            _unityContainer = new UnityRegister(null).Register();

            // Assert
            _unityContainer.Should().NotBeNull();

            CheckFullName(typeof(IRepository<Customer>).FullName);
            CheckFullName(typeof(ICustomerService).FullName);
        }

        private void CheckFullName(string fullName)
        {
            _unityContainer
             .Registrations
             .FirstOrDefault(x => x.RegisteredType.FullName == fullName)
             .Should().NotBeNull();
        }
    }
}
