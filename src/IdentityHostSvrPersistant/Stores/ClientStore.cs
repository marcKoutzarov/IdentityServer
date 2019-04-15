using IdentityHostSvr.Interfaces.Repositories;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                ClientSecrets = {new Secret((Poco.Secret).ToSha512()) }, 
                AccessTokenType = GetTokenType(Poco.AccessTokenType), 
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AccessTokenLifetime = Poco.AccessTokenLifeTime,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials, 
                AllowedScopes = GetClientScopes(Poco.ApiScopes),
              //  Claims
                
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

        private List<string> GetClientScopes(List<ClientScopePoco> scopes)
        {
            List<string> results= new List<string>();

            foreach (ClientScopePoco s in scopes)
            {
                results.Add(s.Scope);
            }
            return results;
        }
    }
}
