using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IResourcesRepo _repo;

        public ClientStore(IResourcesRepo repo)
        {
            _repo = repo;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var Poco = _repo.FindClientByUsernameAsync(clientId).Result;

            Client c = new Client
            {
                ClientId = Poco.ClientUserName,
                ClientName = Poco.ClientUserName,
                Description = Poco.Description,
                ClientSecrets = { new Secret(Poco.Secret)}, 
                AccessTokenType = GetTokenType(Poco.AccessTokenType), 
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AccessTokenLifetime = Poco.AccessTokenLifeTime,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials, 
                AllowedScopes = GetScopes(Poco.ApiScopes),
             };
            return Task.FromResult(c);
        }

        private AccessTokenType GetTokenType(string type) {
            if (type== "REF")
            {
                return AccessTokenType.Reference;
            }
            else
            {
                return AccessTokenType.Jwt;
            }
        }

        private List<string> GetScopes(List<ScopePoco> scopes)
        {
            List<string> results= new List<string>();

            foreach (ScopePoco s in scopes)
            {
                results.Add(s.Scope);
            }
            return results;
        }
    }
}
