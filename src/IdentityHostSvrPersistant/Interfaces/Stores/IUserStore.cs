using IdentityHostSvr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Interfaces.Stores
{
   public interface IUserStore
    {
       User GetUser(string Username);
       User GetUserBySubject(string SubjectId);
    }
}
