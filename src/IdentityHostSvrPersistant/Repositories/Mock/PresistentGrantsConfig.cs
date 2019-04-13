using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;


namespace IdentityHostSvr.Repositories.Mock
{
    public static class PresistentGrantsConfig
    {
        private static List<PersistedGrant> _grants = new List<PersistedGrant>();

        public static IEnumerable<PersistedGrant> GetAll()
        {
            return _grants;
        }

        public static void Add(PersistedGrant g)
        {
            _grants.Add(g);

            var k = "";
        }

        public static PersistedGrant GetByKey(string key)
        {
            PersistedGrant g = null;
            g = _grants.FirstOrDefault(c => c.Key == key);
            return g;
        }
        public static void RemoveByKey(string key)
        {
            var r = _grants.ToList().Where(c => c.Key != key);
            _grants = r.ToList< PersistedGrant>();
        }
    }
}
