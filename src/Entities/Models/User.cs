using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySvr.Entities.Models
{
    public class User
    {
        public string SubjectId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AllowedClients { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public string Salt { get; set; } = "";
        public List<Claim> Claims => GetUserClaims(this);


        //build claims array from user data
        public static List<Claim> GetUserClaims(User user)
        {
            return new Claim[]
            {
            new Claim(JwtClaimTypes.Subject, user.SubjectId.ToString() ?? ""),
            new Claim(JwtClaimTypes.Name, (!string.IsNullOrEmpty(user.GivenName) && !string.IsNullOrEmpty(user.FamilyName)) ? (user.GivenName + " " + user.FamilyName) : ""),
            new Claim(JwtClaimTypes.Email, user.Email  ?? ""),
            new Claim(JwtClaimTypes.Role, user.Role)
            }.ToList<Claim>();

        }
    }
}
