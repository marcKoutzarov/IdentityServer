using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.pocos
{
    public class ScopePoco
    {
        public int Id { get; set; }

        public string Api { get; set; }

        public string Scope { get; set; }
    }
}
