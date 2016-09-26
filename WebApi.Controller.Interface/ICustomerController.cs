using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IEnumerable<CustomerDto>> GetAsync();

        Task<CustomerDto> GetAsync(int id);

        Task<CustomerDto> PostAsync(Customer customer);

        Task DeleteAsync(int id);
    }
}
