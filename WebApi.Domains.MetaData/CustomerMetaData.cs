using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domains.MetaData
{
    public class CustomerMetaData
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is empty")]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
