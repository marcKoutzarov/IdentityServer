using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityHostSvr.Models
{
    public static class ClientsConfig
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Client1",

                    ClientName ="TheClient1Name",

                    Description ="",

                    ClientSecrets ={new Secret("Client1Secret".Sha256())},  //secret for authentication (Keep this code always on the server (note)

                    AccessTokenType = AccessTokenType.Reference,   // a jwt token 
                    AlwaysSendClientClaims =true,
                    AlwaysIncludeUserClaimsInIdToken= true,
                    AllowedGrantTypes =GrantTypes.ClientCredentials,  // no interactive user, use the clientid/secret for authentication

                    AllowedScopes =new List<string>{
                      new string("api1.read"),
                      new string("api2.write")
                    },
                    AuthorizationCodeLifetime =300,
                    IdentityTokenLifetime = 300,

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name,"Bob"),
                        new Claim(JwtClaimTypes.Email, "bob@test.com"),
                        new Claim(JwtClaimTypes.Role,"user"),
                         
                    }


                },

                new Client
                {
                    ClientId = "Client2",
                    ClientName ="TheClient2Name",
                    Description ="",
                    ClientSecrets ={new Secret("Client2Secret".Sha256())},   //secret for authentication (Keep this code always on the server (note)
                    AccessTokenType = AccessTokenType.Jwt,  // a reference token 
                    AlwaysSendClientClaims =true,
                    AlwaysIncludeUserClaimsInIdToken= true,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,  // no interactive user, use the clientid/secret for authentication
                    AllowedScopes =new List<string>{
                       new string("api2.read")
                    },
                    AuthorizationCodeLifetime =300,
                    IdentityTokenLifetime = 300,

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name,"Alice"),
                        new Claim(JwtClaimTypes.Email, "alice@test.com"),
                        new Claim(JwtClaimTypes.Role,"user"),
                    }

                }
            };
        }
    }
}
