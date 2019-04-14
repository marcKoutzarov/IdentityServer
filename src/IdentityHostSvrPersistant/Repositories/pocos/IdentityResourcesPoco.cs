using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.pocos
{
    public class IdentityResourcesPoco : CreatedBase
    {
        public IdentityResourceType IdentityResourceType { get; set; }
        public string Name { get; set; }
        public List<ClaimPoco> UserClaims { get; set; }

    }

    public enum IdentityResourceType
    {
       OpenId,
       Profile
    }
}
