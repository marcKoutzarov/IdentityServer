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
                    Password = CreateHashedPasword("bob","1234"),
                    Salt ="1234",
                    Email ="bob@email.com",
                    GivenName ="alice",
                    FamilyName ="in worderland",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="Rolebob",
                    DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
 
                },
                   new UserPoco{
                    SubjectId="2",
                    Username="alice",
                    Password = CreateHashedPasword("alice","5678"),
                    Salt ="5678",
                    Email ="alice@email.com",
                    GivenName ="Bob",
                    FamilyName ="the builder",
                    IsActive =true,
                    ProviderName ="" ,
                    ProviderSubjectId ="",
                    Role ="roleAlice",
                     DateCreated=new DateTime().Date,
                    DateUpdated=new DateTime().Date,
                    CreatedBy ="test",
                    UpdatedBy ="test"
                }};

        }

        private static string CreateHashedPasword(string password, string salt)
        {
            var StrToHash = password + salt;
            var result = new Secret("Client1Secret".Sha512());
            return result.Value;
        }

    }
}
