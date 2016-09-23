using WebApi.Domains;
using WebApi.Dto;

namespace WebApi.Controller.Implementation.Translator
{
    public class CustomerTranslator
    {
        public static CustomerDto Translate(Customer customer)
        {
            return new CustomerDto
            {
                FirstName = customer.Name,
                Id = customer.Id,
                LastName = customer.LastName
            };
        }
    }
}
