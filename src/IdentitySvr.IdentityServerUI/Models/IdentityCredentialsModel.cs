using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.IdentityServerUI.Models
{
    public class IdentityCredentialsModel
    {

        public string IdentityServer { get; set; } = "";

        public string ClientUserName { get; set; } = "";

        public string ClientSecret { get; set; } = "";

        public string ApiUserName { get; set; } = "";

        public string ApiSecret { get; set; } = "";

        public string UserUserName { get; set; } = "";

        public string UserSecret { get; set; } = "";

        public string ReferenceToken { get; set; } = "";

        public string ClaimsToken { get; set; } = "";
    }
}
