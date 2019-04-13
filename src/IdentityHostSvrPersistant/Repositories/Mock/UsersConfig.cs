using IdentityHostSvr.Models;
using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.Mock
{
    public static class UsersConfig
    {


        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Email ="alice@go.go",
                    Role ="userAlice",
                    IsActive =true,
                    FamilyName ="wonderland",
                    GivenName ="Alice",
                    Salt=""

                    
                    
                },
                new User
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Email ="bob@go.go",
                    Role ="userBob",
                    IsActive =true,
                    FamilyName ="The Builder",
                    GivenName ="Bob",
                    Salt=""
                }
            };
        }
    }
}
