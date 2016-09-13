using System;

namespace WebApi.Domains
{
    public class BaseRequest
    {
        public int Id { get; set; }
        
        public DateTime RequestTime { get; set; }

        public string ClientIpAddress { get; set; }

        public string UserAgent { get; set; }
    }
}