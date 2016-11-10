using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Domains;

namespace WebApi.Common.Utility
{
    public static class UserManager
    {
        private static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    EmailId = "adi***.***@gmail.com",
                    FirstName = "All",
                    Id = 1,
                    LastName = "Roles",
                    Password = "test",
                    PhoneNumber = "345-678-1234",
                    Roles = new [] {Roles.Read.ToString(), Roles.Write.ToString(), Roles.Delete.ToString()},
                    UserName = "aditya",
                    EncodedCredential = "YWRpdHlhOnRlc3Q="
                },
                new User
                {
                    EmailId = "test***.***@gmail.com",
                    FirstName = "Read",
                    Id = 2,
                    LastName = "Roles Only",
                    Password = "test1",
                    PhoneNumber = "123-456-7890",
                    Roles = new [] {Roles.Read.ToString()},
                    UserName = "aditya1",
                    EncodedCredential = "YWRpdHlhOnRlc3Q#"
                }
            };
        }

        public static User GetUserByPassword(string password)
        {
            var user = default(User);

            try
            {
                // Basic YXWZXTYUYUYU$$
                password = password.Split(' ')[1];

                user = GetUsers().ToList().FirstOrDefault(x => x.EncodedCredential.Equals(password, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                
            }

            return user;
        }
    }
}
