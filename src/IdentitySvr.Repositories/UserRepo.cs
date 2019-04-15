using IdentityHostSvr.Interfaces.Repositories;
using IdentityHostSvr.Repositories.InMemoryData;
using IdentitySvr.Entities.Pocos;

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

        UserPoco IUserRepo.GetUser(string Username)
        {
            throw new System.NotImplementedException();
        }

        UserPoco IUserRepo.GetUserById(string Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
