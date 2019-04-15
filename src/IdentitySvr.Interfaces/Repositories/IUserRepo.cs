
using IdentitySvr.Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Interfaces.Repositories
{
    public interface IUserRepo
    {
        UserPoco GetUser(string Username);

        UserPoco GetUserById(string Id);

    }
}
