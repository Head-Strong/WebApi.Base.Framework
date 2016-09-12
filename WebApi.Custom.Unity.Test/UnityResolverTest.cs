using System;
using FluentAssertions;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using WebApi.Service.Implementation;

namespace WebApi.Custom.Unity.Test
{
    [TestFixture]
    public class UnityResolverTest
    {
        private IUnityContainer _unityContainer;
        private UnityResolver _unityResolver;

        [SetUp]
        public void Setup()
        {
            _unityContainer = new UnityRegister().Register();
            
            _unityResolver = new UnityResolver(_unityContainer);
        }

        [Test]
        public void Resolved_Service()
        {
            var customerService = _unityResolver.GetService(typeof(CustomerService));

            customerService.Should().NotBeNull();

        }

        [Test]
        public void Resolved_Services()
        {
            var customerService = _unityResolver.GetServices(typeof(CustomerService));

            customerService.Should().NotBeNull();
        }

        [Test]
        public void Resolve_Container()
        {
            Assert.Throws<ArgumentNullException>(() => new UnityResolver(null));            
        }
    }
}
