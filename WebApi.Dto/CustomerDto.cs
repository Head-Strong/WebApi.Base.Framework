using WebApi.Domains;

namespace WebApi.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static implicit operator CustomerDto(Customer customer)
        {
            return new CustomerDto
            {
                FirstName = customer.Name,
                Id = customer.Id,
                LastName = customer.LastName
            };
        }

        //public static implicit operator Customer(CustomerDto customerDto)
        //{
        //    return new Customer
        //    {

        //    };
        //}
    }
}
