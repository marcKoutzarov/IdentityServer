﻿
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySvr.Interfaces.Repositories
{
    public interface IResourcesRepo
    {

        Task<ApiResourcePoco> FindApiRecourceByNameAsync(string name);

        Task<IEnumerable<ApiResourcePoco>> FindApiRecourceByScopesAsync(IEnumerable<string> scopeNames);
      
        Task<IEnumerable<IdentityResourcesPoco>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames);
        
        Task<IEnumerable<IdentityResourcesPoco>> GetAllIdentityResoucesAsync();
        
        Task<IEnumerable<ApiResourcePoco>> GetAllApiRecourcesAsync();

        Task<ClientPoco> FindClientByUsernameAsync(string clientName);

        Task<List<ClientScopePoco>> FindClientScopesAsync(string clientName);

        Task<List<ClientPoco>> GetAllClientsAsync(string filter="");

        Task<List<ApiScopePoco>> FindApiScopesAsync(string apiName);
    }
}
