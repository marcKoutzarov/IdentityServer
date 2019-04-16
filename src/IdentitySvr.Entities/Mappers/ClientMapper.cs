using IdentityModel;
using IdentityServer4.Models;
using IdentitySvr.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySvr.Entities.Mappers
{
    public static class ClientMapper
    {
        public static Client Map(ClientPoco poco) {
            var result=new Client
            {
                // TODO hard coded configuration
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                // TODO Db Configuration 
                ClientId = poco.ClientUserName,
                ClientName = poco.ClientUserName,
                Description = poco.Description,
                ClientSecrets = {new Secret((poco.Secret).Sha256())},
                AccessTokenType = MapTokenType(poco.AccessTokenType),
                AccessTokenLifetime = poco.AccessTokenLifeTime,
                AllowedScopes = MapClientScopes(poco.ApiScopes),
               // TODO need to add userclaims here
                //  Claims
            };

            return result;
        }

        public static ClientPoco Map(Client client)
        {
            var result = new ClientPoco
            {
                ClientUserName= client.ClientId,
                Description = client.Description,
                Secret = "",
                AccessTokenType = MapTokenType(client.AccessTokenType),
                AccessTokenLifeTime = client.AccessTokenLifetime,
                ApiScopes = MapClientScopes(client.AllowedScopes, client.ClientId),
                //  Claims
            };

            return result;
        }


        public static AccessTokenType MapTokenType(string type)
        {
            if (type == "REF")
            {
                return AccessTokenType.Reference;
            }
            else
            {
                return AccessTokenType.Jwt;
            }
        }

        public static string MapTokenType(AccessTokenType type)
        {
            if (type == AccessTokenType.Reference)
            {
                return "REF";
            }
            else
            {
                return "JWT";
            }
        }

        public static List<string> MapClientScopes(List<ClientScopePoco> scopes)
        {
            List<string> results = new List<string>();

            foreach (ClientScopePoco s in scopes)
            {
                results.Add(s.Scope);
            }
            return results;
        }

        public static List<ClientScopePoco>  MapClientScopes(ICollection<string> scopes, string client)
        {
            List<ClientScopePoco> results = new List<ClientScopePoco>();
            foreach (string s in scopes)
            {
                results.Add(new ClientScopePoco {
                    Scope = s, Client= client, Api=""
                    //Api=  todo parse th api out of tring 
                });
            }

            return results;
        }
    }
}
