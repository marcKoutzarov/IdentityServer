using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;


namespace IdentityHostSvr.Repositories
{
    public static class IdentityResourcesConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
               new IdentityResources.Profile{
                   Name ="profile1" ,
                   UserClaims ={
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Subject
                  }

               },

                new IdentityResources.OpenId(){

                  Name ="openid1",
                  UserClaims ={
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Subject
                  }
              }

            };
        }
    }
}
