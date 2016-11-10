using System.Collections.Generic;

namespace WebApi.Domains
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public string[] Roles { get; set; }

        public string EncodedCredential { get; set; }
    }   
}
