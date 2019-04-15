using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Entities.Pocos
{
    public class ApiResourcePoco : CreatedBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ApiSecrets { get; set; }
        public bool Enabled { get; set; }
        public List<ApiScopePoco>  ApiScopes { get; set; }
        public List<ClaimPoco> UserClaims { get; set; }

    }
}
