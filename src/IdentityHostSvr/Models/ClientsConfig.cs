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
                   
                    AccessTokenType = AccessTokenType.Jwt,   // a jwt token 

                    AlwaysSendClientClaims =true,

                    AlwaysIncludeUserClaimsInIdToken= true,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        //GrantTypes.ClientCredentials,  // no interactive user, use the clientid/secret for authentication

                    AllowedScopes = {"api1","api2"}, // scopes that client has access to

                    AuthorizationCodeLifetime =300,

                    IdentityTokenLifetime = 300,

                    Claims = new List<Claim>{new Claim("usertype", "user"),new Claim("email", "bob@bob.com") }
                },

                new Client
                {
                    ClientId = "Client2",

                    ClientName ="TheClient2Name",

                    Description ="",
                  
                    ClientSecrets ={new Secret("Client2Secret".Sha256())},   //secret for authentication (Keep this code always on the server (note)
                   
                    AccessTokenType = AccessTokenType.Reference,  // a reference token 

                    AlwaysSendClientClaims =true,

                    AlwaysIncludeUserClaimsInIdToken= true,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials ,  // no interactive user, use the clientid/secret for authentication

                    AllowedScopes = {"api1","api2"}, // scopes that client has access to

                    AuthorizationCodeLifetime =300,

                    IdentityTokenLifetime = 300,

                    Claims = new List<Claim>{new Claim("usertype", "user"),new Claim("email", "bob@bob.com") }
                }




            };
        }
    }
}
