using IdentityHostSvr.Interfaces;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Interfaces.Stores;
using IdentityHostSvr.Models;
using IdentityHostSvr.Repositories.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Stores
{
    public class UserStore : IUserStore
    {
        private List<User> _users = UsersConfig.GetUsers();
        private IUserRepo _repo;

        public UserStore(IUserRepo UserRepo)
        {
            _repo = UserRepo;
        }



        public User GetUser(string Username)
        {
            User g = null;
            g = _users.FirstOrDefault(c => c.Username == Username);
            return g;
        }

        public User GetUserBySubject(string SubjectId)
        {
            User g = null;
            g = _users.FirstOrDefault(c => c.SubjectId== SubjectId);
            return g;
        }

    }
}
