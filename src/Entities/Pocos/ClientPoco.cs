using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Entities.Pocos
{
    public class ClientPoco: CreatedBase
    {
        public int Id { get; set; }
        public string ClientUserName { get; set; }
        public string Description { get; set; }
        public string Secret { get; set; }
        public string AccessTokenType { get; set; }
        public int AccessTokenLifeTime { get; set; }
        public string Role { get; set; }
        public bool Enabled { get; set; }
        public List<ClientScopePoco> ApiScopes { get; set; }
    }
}
