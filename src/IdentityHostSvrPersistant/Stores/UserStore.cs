using IdentityHostSvr.Interfaces;
using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Interfaces.Stores;
using IdentityHostSvr.Models;
using IdentityHostSvr.Repositories.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Stores
{
    public class UserStore : IUserStore
    {
        private IUserRepo _repo;

        public UserStore(IUserRepo UserRepo)
        {
            _repo = UserRepo;
        }



        public User GetUser(string Username)
        {
            UserPoco g = _repo.GetUser(Username);
            User user = new User
            {
                SubjectId = g.SubjectId,
                Username = g.Username,
                AllowedClients= g.AllowedClients,
                Salt = g.Salt,
                Email = g.Email,
                FamilyName =g.FamilyName,
                GivenName =g.GivenName,
                Password = g.Password,
                IsActive =g.IsActive ,
                Role =g.Role ,
                ProviderName =g.ProviderName ,
                ProviderSubjectId =g.ProviderSubjectId
            };

            return user;
        }

        public User GetUserBySubject(string SubjectId)
        {
            UserPoco g = _repo.GetUserById(SubjectId);

            User user = new User
            {
                SubjectId = g.SubjectId,
                Username = g.Username,
                Salt = g.Salt,
                Email = g.Email,
                FamilyName = g.FamilyName,
                GivenName = g.GivenName,
                Password = g.Password,
                IsActive = g.IsActive,
                Role = g.Role,
                ProviderName = g.ProviderName,
                ProviderSubjectId = g.ProviderSubjectId
            };

            return user;
        }
    }
}
