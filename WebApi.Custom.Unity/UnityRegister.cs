using Microsoft.Practices.Unity;
using WebApi.Controller.Implementation;
using WebApi.Controller.Interface;
using WebApi.Domains;
using WebApi.Repository.Implementation;
using WebApi.Repository.Interface;
using WebApi.Service.Implementation;
using WebApi.Service.Interface;

namespace WebApi.Custom.Unity
{
    public class UnityRegister
    {
        private readonly IUnityContainer _unityContainer;

        public UnityRegister() : this(null)
        {
        }

        public UnityRegister(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer ?? new UnityContainer();
        }

        public IUnityContainer Register()
        {
            RegisterRepository();
            RegisterServices();
            RegisterController();

            return _unityContainer;
        }

        public IUnityContainer RegisterRepository()
        {
            return _unityContainer.RegisterType<IRepository<Customer>, CustomerRepository>(new HierarchicalLifetimeManager());
        }

        public IUnityContainer RegisterServices()
        {
            return _unityContainer.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
        }

        public IUnityContainer RegisterController()
        {
            return
                _unityContainer.RegisterType<ICustomerController, CustomerController>(new HierarchicalLifetimeManager());
        }
    }
}
