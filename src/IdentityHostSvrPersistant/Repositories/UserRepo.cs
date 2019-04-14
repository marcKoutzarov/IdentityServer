using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.InMemoryData;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Repositories
{
    public class UserRepo : IUserRepo
    {
        public UserPoco GetUser(string Username)
        {
           return UserData.GetUsers(Username);
        }

        public UserPoco GetUserById(string id)
        {
            var i =int.Parse(id);
            return UserData.GetUsers(i);
        }
    }
}
