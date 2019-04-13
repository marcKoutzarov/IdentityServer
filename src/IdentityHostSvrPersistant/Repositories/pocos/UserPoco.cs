using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.pocos
{
    public class UserPoco : CreatedBase
    {
        public string SubjectId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public string Salt { get; set; } = "";
       
    }
}
