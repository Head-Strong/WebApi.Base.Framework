namespace WebApi.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public static implicit operator Customer(CustomerDto customerDto)
        //{
        //    return new Customer
        //    {

        //    };
        //}
    }
}
