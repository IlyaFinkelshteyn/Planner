using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Middleware
{
    public class TokenProviderOptions
    {
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);
        public string Issuer { get; set; }
        public string Path { get; set; } = "/token";
        public SigningCredentials SigningCredentials { get; set; }
    }
}