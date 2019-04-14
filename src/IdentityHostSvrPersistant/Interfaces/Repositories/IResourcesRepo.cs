using IdentityHostSvr.Repositories.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Interfaces.Repositories
{
   public interface IResourcesRepo
    {

        Task<ApiResourcePoco> FindApiRecourceByNameAsync(string name);

        Task<IEnumerable<ApiResourcePoco>> FindApiRecourceByScopesAsync(IEnumerable<string> scopeNames);
      
        Task<IEnumerable<IdentityResourcesPoco>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames);
        
        Task<IEnumerable<IdentityResourcesPoco>> GetAllIdentityResoucesAsync();
        
        Task<IEnumerable<ApiResourcePoco>> GetAllApiRecourcesAsync();

        Task<ClientPoco> FindClientByUsernameAsync(string clientName);

        Task<List<ScopePoco>> FindClientScopesAsync(string clientName);
       
        Task<List<ScopePoco>> FindApiScopesAsync(string apiName);
    }
}
