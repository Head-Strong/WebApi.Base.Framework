using System.Collections.Generic;
using WebApi.Domains;
using WebApi.Dto;

namespace WebApi.Controller.Interface
{
    public interface ICustomerController
    {
        IEnumerable<CustomerDto> Get();

        CustomerDto Get(int id);

        CustomerDto Post(Customer customer);

        void Delete(int id);
    }
}
