using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;


namespace IdentityHostSvr.Models
{
    public static class ApiResourcesConfig
    {
        public static IEnumerable<ApiResource> GetApis()
        {

            return new List<ApiResource>
            {
                new ApiResource{
                   Name="api1",
                   Description="",
                   DisplayName="My API 1",
                   ApiSecrets={new Secret("Api1Secret".Sha256())},
                   Scopes=new List<Scope>(){new Scope("api1")},
                   UserClaims ={
                    JwtClaimTypes.Name,JwtClaimTypes.Email,JwtClaimTypes.Role}
                },


                new ApiResource{
                   Name="api2",
                   Description="",
                   DisplayName="My API 2",
                   ApiSecrets={new Secret("Api2Secret".Sha256())},
                   Scopes=new List<Scope>(){new Scope("api2")},
                   UserClaims ={
                    JwtClaimTypes.Name,JwtClaimTypes.Email, JwtClaimTypes.Role}

                }

            };

        }
    }
}
