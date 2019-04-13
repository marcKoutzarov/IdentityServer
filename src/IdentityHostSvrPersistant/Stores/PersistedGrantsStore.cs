using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;
using IdentityHostSvr.Repositories.Mock;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Stores
{
    public class PersistedGrantsStore : IPersistedGrantStore
    {
        private readonly IGrantsRepo _grantRepo; 

        public PersistedGrantsStore(IGrantsRepo grantsRepo)
        {
           _grantRepo = grantsRepo;
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
           IEnumerable<PersistedGrant> result = new List<PersistedGrant>(); 
           IEnumerable<GrantPoco> grants = _grantRepo.GetAll();

           foreach (GrantPoco p in grants)
           {
                result.Append(new PersistedGrant {
                    ClientId = p.ClientId,
                    CreationTime = p.CreationTime, 
                    Data=p.Data,
                    Key =p.Key,
                    Expiration = p.Expiration,
                    SubjectId = p.SubjectId,
                    Type =p.Type
                });
           }

            //return Task <IEnumerable <PersistedGrant>>.FromResult(PresistentGrantsConfig.GetAll());
            return Task<IEnumerable<PersistedGrant>>.FromResult(result);
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            return Task<PersistedGrant>.FromResult(PresistentGrantsConfig.GetByKey(key));
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            PresistentGrantsConfig.RemoveByKey(key);
            return Task.FromResult(0);
        }

         public Task StoreAsync(PersistedGrant grant)
        {
           PresistentGrantsConfig.Add(grant);
            return Task.FromResult(0);
        }
    }
}
