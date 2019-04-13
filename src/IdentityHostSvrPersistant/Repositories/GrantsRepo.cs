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

        public IEnumerable<GrantPoco> GetAll()
        {
            return GrantsData.GetAll();
        }

        public GrantPoco GetByKey(string key)
        {
            return GrantsData.GetByKey(key);
        }

        public void RemoveByKey(string key)
        {
            GrantsData.RemoveByKey(key);
        }
    }
}
