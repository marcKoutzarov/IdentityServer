using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Entities.Pocos
{
    public class ClientScopePoco
    {
        public int ScopeId { get; set; }
        public string Client { get; set; }
        public string Api { get; set; }
        public string Scope { get; set; }

    }
}
