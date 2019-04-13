using IdentityHostSvr.Repositories.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Interfaces.Repositories
{
   public interface IGrantsRepo
    {
      IEnumerable<GrantPoco> GetAll();
      void Add(GrantPoco Grant);
      GrantPoco GetByKey(string key);
      void RemoveByKey(string key);
    }
}
