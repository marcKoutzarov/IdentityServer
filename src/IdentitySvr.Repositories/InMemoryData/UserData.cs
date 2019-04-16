using IdentitySvr.Core;
using IdentitySvr.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySvr.Repositories.InMemoryData
{
    public class UserData
    {
        public static UserPoco GetUsers(string Username)
        {
            UserPoco g = null;
            g = GetUsers().FirstOrDefault(c => c.Username == Username);
            return g;
        }

        public static UserPoco  GetUsers(int id)
        {
            UserPoco g = null;
            g = GetUsers().FirstOrDefault(c => c.SubjectId == id.ToString());
            return g;
        }

        public static IEnumerable<UserPoco> GetUsers()
        {

            return new List<UserPoco>
            {
                new UserPoco{
                    SubjectId="1",
                    Username="bob",
                    Password =PasswordGenerator.CreateNew("password","1111"),
                    Salt ="1111",
                    Email ="bob@email.com",
                    GivenName ="Bob",
                    FamilyName ="the Builder",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="admin",
                    AllowedClients="Client1;Client2",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
 
                },
                   new UserPoco{
                    SubjectId="2",
                    Username="alice",
                    Password = PasswordGenerator.CreateNew("password","5555"),
                    Salt ="5555",
                    Email ="alice@email.com",
                    GivenName ="Alice",
                    FamilyName ="Wonderland",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="employee",
                    AllowedClients="Client1;Client3",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
                  },
                   new UserPoco{
                    SubjectId="3",
                    Username="george",
                    Password = PasswordGenerator.CreateNew("password","6666"),
                    Salt ="6666",
                    Email ="george@email.com",
                    GivenName ="George",
                    FamilyName ="Jonhson",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="customer",
                    AllowedClients="Client1;Client2;Client3",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
                }

            };
        }
    }
}
