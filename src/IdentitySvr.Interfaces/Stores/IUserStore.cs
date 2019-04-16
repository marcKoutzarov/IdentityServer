using IdentitySvr.Entities.Models;

namespace IdentitySvr.Interfaces.Stores
{
    public interface IUserStore
    {

        User GetUser(string Username);

        User GetUserBySubject(string SubjectId);

    }
}
