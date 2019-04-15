using IdentityHostSvr.Interfaces.Repositories;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentitySvr.Entities.Mappers;
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Host.Stores
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
            ApiResourcePoco apiPoco = _repo.FindApiRecourceByNameAsync(name).Result;
            ApiResource Result = ApiMapper.Map(apiPoco);
            return Task.FromResult<ApiResource>(Result);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apis = _repo.FindApiRecourceByScopesAsync(scopeNames).Result; //ApiResourcesConfig.GetApis();

            List<ApiResource> result = new List<ApiResource>();
            foreach (ApiResourcePoco a in apis)
            {
                result.Add(ApiMapper.Map(a));
            }
            return Task.FromResult<IEnumerable<ApiResource>>(result);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            // var A = IdentityResourcesConfig.GetIdentityResources();
            IEnumerable<IdentityResourcesPoco> IdentityPocos = _repo.GetAllIdentityResoucesAsync().Result;
            List<IdentityResource> result = new List<IdentityResource>();

            foreach(IdentityResourcesPoco ip in IdentityPocos)
            {
                result.Add(ReturnIdentityResource(ip));
            }

            return Task.FromResult<IEnumerable<IdentityResource>>(result);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
           
            // get all Identity resources
            IEnumerable<IdentityResourcesPoco> IdentityPocos = _repo.GetAllIdentityResoucesAsync().Result;
            List<IdentityResource> Identityresult = new List<IdentityResource>();
            foreach (IdentityResourcesPoco ip in IdentityPocos)
            {
                Identityresult.Add(ReturnIdentityResource(ip));
            }

            // get all api resources
            IEnumerable<ApiResourcePoco> ApiPocos = _repo.GetAllApiRecourcesAsync().Result;
            List<ApiResource> Apiresult = new List<ApiResource>();
            foreach (ApiResourcePoco a in ApiPocos)
            {
                Apiresult.Add(ApiMapper.Map(a));
            
            }


            var r = new Resources(Identityresult, Apiresult);
            return Task.FromResult<Resources>(r);
        }
















        private IdentityResource ReturnIdentityResource(IdentityResourcesPoco a)
        {

            if (a.IdentityResourceType == IdentityResourceType.OpenId)
            {
                return new IdentityResources.OpenId()
                {
                    Name = a.Name,
                    UserClaims ={
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Subject
                    }
                };
            }
            else if (a.IdentityResourceType == IdentityResourceType.Profile)
            {

                return new IdentityResources.OpenId(){
                    Name = a.Name,
                    UserClaims ={
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Subject
                    }
                };

            }else
            {
                return null;
            }
        }

   

        private List<string> ReturnApiUserClaims(List<ClaimPoco> claims)
        {
            List<string> result = new List<string>();

            foreach (ClaimPoco c in claims)
            {
               result.Add(new string(c.ClaimName));
            }
            return result;
        }

    }
}

