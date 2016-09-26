using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domains
{
    public class Customer : BaseRequest, IValidatableObject
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => (Name + " " + LastName).Trim();

        public override string ToString()
        {
            return $"Id : {Id}, Name : {FullName}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResult = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResult.Add(new ValidationResult("Please provide Name", new List<string> { "Name" }));
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                validationResult.Add(new ValidationResult("Please provide Last Name", new List<string> { "LastName" }));
            }

            return validationResult;
        }
    }
}
