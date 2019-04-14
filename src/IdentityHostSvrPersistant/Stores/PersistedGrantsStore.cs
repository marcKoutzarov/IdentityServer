using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.pocos;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<GrantPoco> grants = _grantRepo.GetAll(subjectId).ToList();

           foreach (GrantPoco p in grants)
           {
                   result.Append(
                       new PersistedGrant {
                           ClientId = p.ClientId,
                           CreationTime = p.CreationTime,
                           Data =p.Data,
                           Key =p.Key,
                           Expiration = p.Expiration,
                           SubjectId = p.SubjectId,
                           Type =p.Type
                       });
            }

            return Task<List<PersistedGrant>>.FromResult(result);
        }
        public Task<PersistedGrant> GetAsync(string key)
        {
            GrantPoco grant = _grantRepo.GetByKey(key);

            PersistedGrant result = new PersistedGrant()
            {
                ClientId = grant.ClientId,
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Key = grant.Key,
                Expiration = grant.Expiration,
                SubjectId = grant.SubjectId,
                Type = grant.Type
            };
           

           return Task<PersistedGrant>.FromResult(result);

        }
        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            _grantRepo.RemoveAll(subjectId, clientId);
            return Task.FromResult(0);
        }
        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            _grantRepo.RemoveAll(subjectId, clientId, type);
            return Task.FromResult(0);
        }
        public Task RemoveAsync(string key)
        {
            _grantRepo.RemoveByKey(key);
            return Task.FromResult(0);
        }
        public Task StoreAsync(PersistedGrant grant)
        {
            GrantPoco p = new GrantPoco
            {
                ClientId=grant.ClientId,
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Key = grant.Key,
                Expiration = grant.Expiration,
                SubjectId = grant.SubjectId,
                Type = grant.Type
              };

            _grantRepo.Add(p);

            return Task.FromResult(0);
        }

    }
}
