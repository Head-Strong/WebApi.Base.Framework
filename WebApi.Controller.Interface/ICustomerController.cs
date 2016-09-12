using System.Collections.Generic;
using WebApi.Domains;

namespace WebApi.Controller.Interface
{
    public interface ICustomerController
    {
        IEnumerable<Customer> Get();

        Customer Get(int id);
    }
}
