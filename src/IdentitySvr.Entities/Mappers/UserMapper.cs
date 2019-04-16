﻿using IdentitySvr.Entities.Models;
using IdentitySvr.Entities.Pocos;

namespace IdentitySvr.Entities.Mappers
{
    public static class UserMapper
    {

       public static User Map(UserPoco p)
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

        public static UserPoco Map(User p)
        {
            UserPoco user = new UserPoco
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
