using IdentityHostSvr.Interfaces.Repositories;
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
            throw new NotImplementedException();
        }

        public IEnumerable<GrantPoco> GetAll()
        {
            throw new NotImplementedException();
        }

        public GrantPoco GetByKey(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
