using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityHostSvr.Models
{
    public static class UsersConfig
    {


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new List<Claim>{
                        new Claim(JwtClaimTypes.Name, "Alice"),
                        new Claim(JwtClaimTypes.Email, "Alice@alice.com"),
                        new Claim(JwtClaimTypes.Role, "Aliceuser")
                    }

                },
                new TestUser
                {
                   
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new List<Claim>{
                        new Claim(JwtClaimTypes.Name, "bob"),
                        new Claim(JwtClaimTypes.Email, "bob@bob.com"),
                        new Claim(JwtClaimTypes.Role, "bobuser")
                    }
                }
            };
        }
    }
}
