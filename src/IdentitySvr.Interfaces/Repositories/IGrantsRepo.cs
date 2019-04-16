using IdentitySvr.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Interfaces.Repositories
{
   public interface IGrantsRepo
    {
      IEnumerable<GrantPoco> GetAll(string subjectId);
      void Add(GrantPoco Grant);
      GrantPoco GetByKey(string key);
      void RemoveByKey(string key);
      void RemoveAll(string subjectId, string clientId);
      void RemoveAll(string subjectId, string clientId, string type);
    }

}
