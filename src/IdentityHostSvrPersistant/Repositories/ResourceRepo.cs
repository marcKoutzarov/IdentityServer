using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Repositories
{
    public class ResourceRepo : IResourcesRepo
    {
        public Task<ApiResourcePoco> FindApiRecourceByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiResourcePoco>> FindApiRecourceByScopesAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScopePoco>> FindApiScopesAsync(string apiName)
        {
            throw new NotImplementedException();
        }

        public Task<ClientPoco> FindClientByUsernameAsync(string clientName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScopePoco>> FindClientScopesAsync(string clientName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResourcesPoco>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResourcesPoco> GetAllIdentityResoucesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
