using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Interfaces.Stores;
using IdentitySvr.Entities.Models;
using IdentitySvr.Entities.Pocos;

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
           return MapUser(_repo.GetUser(Username));
        }

        public User GetUserBySubject(string SubjectId)
        {
           return MapUser(_repo.GetUserById(SubjectId));
        }

        private User MapUser(UserPoco p)
        {
            User user = new User
            {
                SubjectId = p.SubjectId,
                Username = p.Username,
                Salt = p.Salt,
                Email = p.Email,
                FamilyName = p.FamilyName,
                GivenName = p.GivenName,
                Password = p.Password,
                IsActive = p.IsActive,
                Role = p.Role,
                ProviderName = p.ProviderName,
                ProviderSubjectId = p.ProviderSubjectId
            };

            return user;

        }


    }
}
