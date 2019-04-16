using IdentitySvr.Entities.Models;
using IdentitySvr.Entities.Pocos;
using IdentitySvr.Entities.Mappers;
using IdentitySvr.Interfaces.Stores;
using IdentitySvr.Interfaces.Repositories;

namespace IdentitySvr.Host.Stores
{
    public class UserStore : IUserStore
    {
        private readonly IUserRepo _repo;

        public UserStore(IUserRepo UserRepo)
        {
            _repo = UserRepo;
        }

        public User GetUser(string Username)
        {
        
           
           return UserMapper.Map(_repo.GetUser(Username));
        }

        public User GetUserBySubject(string SubjectId)
        {
           return UserMapper.Map(_repo.GetUserById(SubjectId));
        }



    }
}
