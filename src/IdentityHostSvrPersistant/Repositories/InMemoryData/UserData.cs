using IdentityHostSvr.Repositories.pocos;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.InMemoryData
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
                    Password = CreateHashedPasword("password","1111"),
                    Salt ="1111",
                    Email ="bob@email.com",
                    GivenName ="bob",
                    FamilyName ="the Builder",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="Rolebob",
                    AllowedClients="Client1",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
 
                },
                   new UserPoco{
                    SubjectId="2",
                    Username="alice",
                    Password = CreateHashedPasword("password","1111"),
                    Salt ="1111",
                    Email ="alice@email.com",
                    GivenName ="alice",
                    FamilyName ="Wonderland",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="roleAlice",
                    AllowedClients="Client1;client2",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
                }};

        }

        private static string CreateHashedPasword(string password, string salt)
        {
            var StrToHash = password + salt;
            var result = new Secret(StrToHash.Sha512());
            return result.Value;
        }

    }
}
