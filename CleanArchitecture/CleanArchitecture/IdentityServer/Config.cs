using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("TestAPIGateway", "All services for testing")
                {
                    Scopes = new List<string>()
                    {
                        "TestAPIGateway.access"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope(name: "TestAPIGateway.access",   displayName: "Access All Service")
            };
        }

        public static IEnumerable<Client> GetClients([FromServices] IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ClientId",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("ClientSecret".Sha256())
                    },
                    AllowedScopes = { "TestAPIGateway.access" },
                    AccessTokenLifetime =3600
                }
            };
        }
    }
}
