using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.pocos;

namespace IdentityHostSvr.Repositories
{
    public class UserRepo : IUserRepo
    {
        public UserPoco GetUser(string Username)
        {
            throw new NotImplementedException();
        }

        public UserPoco GetUserById(string Id)
        {
            throw new NotImplementedException();
        }

    }
}
