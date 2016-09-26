using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domains
{
    public interface IBaseRequest : IValidatableObject
    {
        int Id { get; set; }
        
        DateTime RequestTime { get; set; }

        string ClientIpAddress { get; set; }

        string UserAgent { get; set; }
    }
}