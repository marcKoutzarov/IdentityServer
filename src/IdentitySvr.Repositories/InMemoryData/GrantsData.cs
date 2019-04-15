
using IdentitySvr.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Repositories.InMemoryData
{
    public static class GrantsData
    {
        private static List<GrantPoco> _grants = new List<GrantPoco>();

        public static IEnumerable<GrantPoco> GetAll(string subjectId)
        {
            var r = _grants.ToList().Where(c => c.SubjectId == subjectId);
            return r;
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

        public static void RemoveAll(string subjectId, string clientId)
        {
            var r = _grants.ToList().Where(c => c.ClientId != clientId & c.SubjectId != subjectId);
            _grants = r.ToList<GrantPoco>();
        }

        public static void RemoveAll(string subjectId, string clientId, string type)
        {
            var r = _grants.ToList().Where(c => c.ClientId != clientId & c.SubjectId != subjectId & c.Type!= type);
            _grants = r.ToList<GrantPoco>();
        }

    }
}
