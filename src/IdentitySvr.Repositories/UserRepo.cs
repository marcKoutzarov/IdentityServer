using IdentitySvr.Interfaces.Repositories;
using IdentitySvr.Repositories.InMemoryData;
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <param name="filter">optional not implemented right now</param>
        /// <returns>IEnumerable<UserPoco></returns>
        public Task<IEnumerable<UserPoco>> GetUsersAsync(string filter = "")
        {
            var users = UserData.GetUsers();
            return Task.FromResult(users);
        }
    }
}
