using IdentitySvr.Entities.Models;

namespace IdentityHostSvr.Interfaces.Stores
{
    public interface IUserStore
    {

        User GetUser(string Username);

        User GetUserBySubject(string SubjectId);

    }
}
