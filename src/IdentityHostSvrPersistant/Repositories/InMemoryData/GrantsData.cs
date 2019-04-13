using IdentityHostSvr.Repositories.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.InMemoryData
{
    public static class GrantsData
    {
        private static List<GrantPoco> _grants = new List<GrantPoco>();

        public static IEnumerable<GrantPoco> GetAll()
        {
            return _grants;
        }
        public static void Add(GrantPoco g)
        {
            _grants.Add(g);
        }

        public static GrantPoco GetByKey(string key)
        {
            GrantPoco g = null;
            g = _grants.FirstOrDefault(c => c.Key == key);
            return g;
        }
        public static void RemoveByKey(string key)
        {
            var r = _grants.ToList().Where(c => c.Key != key);
            _grants = r.ToList<GrantPoco>();
        }
    }
}
