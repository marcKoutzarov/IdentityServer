using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;
using IdentityHostSvr.Repositories.Mock;
using IdentityHostSvr.Repositories;
using IdentityHostSvr.Interfaces.Repositories;

namespace IdentityHostSvr.Stores
{
    public class ResourceStore : IResourceStore
    {
        private IResourcesRepo _repo;

        public ResourceStore(IResourcesRepo ResourceRepo)
        {
            _repo = ResourceRepo;
        }
        
        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var Apis = ApiResourcesConfig.GetApis();
            ApiResource Result = null;

            foreach ( ApiResource A in Apis)
            {
                if (A.Name == name)
                {
                    Result = A;
                    return Task.FromResult<ApiResource>(Result);
                }
            }

            return Task.FromResult<ApiResource>(Result);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var A = ApiResourcesConfig.GetApis();
            return Task.FromResult<IEnumerable<ApiResource>>(A);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var A = IdentityResourcesConfig.GetIdentityResources();
            return Task.FromResult<IEnumerable<IdentityResource>>(A);
        }

        public Task<Resources> GetAllResourcesAsync()
        {   
            var idR = IdentityResourcesConfig.GetIdentityResources();
            var ApiR = ApiResourcesConfig.GetApis();
            var r = new Resources(idR, ApiR);
            return Task.FromResult<Resources>(r);
        }

    }
}

