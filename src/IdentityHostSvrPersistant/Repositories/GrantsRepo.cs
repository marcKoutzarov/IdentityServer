using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.InMemoryData;
using IdentityHostSvr.Repositories.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories
{
    public class GrantsRepo : IGrantsRepo
    {
        public void Add(GrantPoco Grant)
        {
            GrantsData.Add(Grant);
        }

        public IEnumerable<GrantPoco> GetAll(string subjectId)
        {
            return GrantsData.GetAll(subjectId);
        }

        public GrantPoco GetByKey(string key)
        {
            return GrantsData.GetByKey(key);
        }

        public void RemoveAll(string subjectId, string clientId)
        {
            GrantsData.RemoveAll(subjectId, clientId);
        }

        public void RemoveAll(string subjectId, string clientId, string type)
        {
            GrantsData.RemoveAll(subjectId, clientId, type);
        }

        public void RemoveByKey(string key)
        {
            GrantsData.RemoveByKey(key);
        }
    }
}
