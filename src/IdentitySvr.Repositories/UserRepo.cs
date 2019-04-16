using IdentitySvr.Interfaces.Repositories;
using IdentitySvr.Repositories.InMemoryData;
using IdentitySvr.Entities.Pocos;

namespace IdentitySvr.Repositories
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
