using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IIdentityHostSvr.Repositories.Mock
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
                    Description ="Client returning a Reference token",
                    ClientSecrets ={new Secret("Client1Secret".Sha256())},  //secret for authentication (Keep this code always on the server (note)
                    AccessTokenType = AccessTokenType.Reference,   // a jwt token 
                    AlwaysSendClientClaims =true,
                    AlwaysIncludeUserClaimsInIdToken= true,
                    AllowedGrantTypes =GrantTypes.ResourceOwnerPasswordAndClientCredentials,  // no interactive user, use the clientid/secret for authentication
                      AllowedScopes =new List<string>{
                      new string("api1.read"),
                      new string( "api1.write"),
                    },

                    AccessTokenLifetime = 20,   // 10 s by intention
                    
                    Claims = new List<Claim>
                    {    new Claim(JwtClaimTypes.Role,"application"),
                        new Claim("Company","Pay_NLD"),
                        new Claim("Department","Legal")
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
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials ,//GrantTypes.ClientCredentials,  // no interactive user, use the clientid/secret for authentication
                    AllowedScopes =new List<string>{
                       new string("api2.read")
                    },

                    AccessTokenLifetime = 20,   // 10 s by intention 

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role,"user"),
                        new Claim("Company","Pay_THA"),
                        new Claim("Department","Legal")
                    }

                }
            };
        }
    }
}
