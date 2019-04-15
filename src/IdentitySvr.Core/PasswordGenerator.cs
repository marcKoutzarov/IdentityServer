using IdentityModel;
using IdentityServer4.Models;
using System;

namespace IdentitySvr.Core
{
    public static class PasswordGenerator
    {

        /// <summary>
        /// Generates a new Sha512 hashed password. The Salt is optional
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <param name="salt">optional salt</param>
        /// <returns></returns>
        public static string CreateNew(string password, string salt="")
        {
            var StrToHash = password + salt;
            var result = new Secret((StrToHash).ToSha512());
            return result.Value;
        }

    }
}
