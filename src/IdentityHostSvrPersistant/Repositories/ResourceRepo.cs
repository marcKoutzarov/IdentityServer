using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.InMemoryData;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Repositories
{
    public class ResourceRepo : IResourcesRepo
    {


        // -------API-------------

        public Task<IEnumerable<ApiResourcePoco>> GetAllApiRecourcesAsync()
        {
            var ApiResources = ResourceData.GetApis();
            return Task.FromResult(ApiResources);
        }

        public Task<ApiResourcePoco> FindApiRecourceByNameAsync(string apiName)
        {
            return Task.FromResult(ResourceData.GetApis(apiName));
        }

        public Task<IEnumerable<ApiResourcePoco>> FindApiRecourceByScopesAsync(IEnumerable<string> scopeNames)
        {
           return Task.FromResult(ResourceData.GetApiRecourceByScopesAsync(scopeNames));
        }


        // -------API SCOPES-------------
        public Task<List<ScopePoco>> FindApiScopesAsync(string apiName)
        {
            var apiScopes = ResourceData.GetApis(apiName).ApiScopes;
            return Task.FromResult(apiScopes);
        }


        
        
        // -------CLIENTS-------------
        public Task<ClientPoco> FindClientByUsernameAsync(string clientName)
        {
            return Task.FromResult(ResourceData.GetClients(clientName));
        }

        // -------CLIENT SCOPES-------------
        public Task<List<ScopePoco>> FindClientScopesAsync(string clientName)
        {
            var ClientScopes = ResourceData.GetClients(clientName).ApiScopes;
            return Task.FromResult(ClientScopes);
        }
    





        // -------IDENTITIES-------------
        public Task<IEnumerable<IdentityResourcesPoco>> GetAllIdentityResoucesAsync()
        {
            var IdentityResources = ResourceData.GetIdentityResources();
            return Task.FromResult(IdentityResources);
        }

        public Task<IEnumerable<IdentityResourcesPoco>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {

            throw new NotImplementedException();
        }

       
    }
}
