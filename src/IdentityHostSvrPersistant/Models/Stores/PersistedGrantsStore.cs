using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;

namespace IdentityHostSvr.Models.Stores
{
    public class PersistedGrantsStore : IPersistedGrantStore
    {
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            return Task <IEnumerable <PersistedGrant>>.FromResult(PresistentGrantsConfig.GetAll());
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
