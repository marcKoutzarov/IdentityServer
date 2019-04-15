using IdentityModel;
using IdentityServer4.Models;
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;

namespace IdentitySvr.Entities.Mappers
{
    /// <summary>
    /// Mapping of Api Resources
    /// </summary>
    public static class ApiMapper
    {        
        /// <summary>
        /// Maps a Api resource poco to a Identity Server ApiResource
        /// </summary>
        /// <param name="poco" cref='ApiResourcePoco'>ApiResourcePoco</param>
        /// <returns cref='ApiResource'>ApiResource</returns>
        public static ApiResource Map(ApiResourcePoco poco)
        {
            ApiResource result = new ApiResource{

                Name = poco.Name,

                ApiSecrets = { new Secret(poco.ApiSecrets.Sha512()) },

                Description = poco.Description,

                DisplayName = poco.DisplayName,

                Enabled = poco.Enabled,

                Scopes = MapApiScopes(poco.ApiScopes),

                UserClaims ={
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Email,
                    JwtClaimTypes.Role,
                    JwtClaimTypes.Subject}
            };

            return result;
        }

        /// <summary>
        /// Maps a Identity Server ApiResource to an Api resource poco to a
        /// </summary>
        /// <param name="poco" cref='ApiResource'>ApiResource</param>
        /// <returns cref='ApiResourcePoco'>ApiResourcePoco</returns>
        public static ApiResourcePoco Map(ApiResource api)
        {
            ApiResourcePoco result = new ApiResourcePoco
            {     Name = api.Name,
                  ApiSecrets = "*****",
                  DisplayName= api.DisplayName, 
                  Description=api.Description,
                  UserClaims= MapUserClaims(api.UserClaims),
                  ApiScopes= MapApiScopes(api.Scopes)
            };
            return result;
        }

        public static List<Scope> MapApiScopes(ICollection<ApiScopePoco> apiScopePoco)
        {
            List<Scope> result = new List<Scope>();
            foreach (ApiScopePoco s in apiScopePoco)
            {
                result.Add(new Scope(s.Scope));
            }
            return result;
        }

        /// <summary>
        /// Maps the Api Scope to ApiScopePoco
        /// </summary>
        /// <param name="apiScopes" cref='Scope'>Collection of Scopes </param>
        /// <returns cref='ApiScopePoco' >List<ApiScopePoco></returns>
        public static List<ApiScopePoco> MapApiScopes(ICollection<Scope> apiScopes)
        {
            List<ApiScopePoco> result = new List<ApiScopePoco>();
            foreach (Scope s in apiScopes)
            {
              result.Add(new ApiScopePoco {
                    Api = "", // last item after dot is the scope api.someOther.scope
                    Scope = s.Name,
                    ScopeId = 0 // We dont know the scope id. 
               });
            }

            return result;
        }

        public static List<ClaimPoco> MapUserClaims(ICollection<string> userClaims)
        {
            List<ClaimPoco> result = new List<ClaimPoco>();

            foreach (string c in userClaims)
            {
                result.Add(new ClaimPoco {ClaimName=c});
            }
            return result;
        }

        public static ICollection<string> MapUserClaims(List<ClaimPoco> userClaims)
        {
            ICollection<string> result = new List<string>();
            // todo convert 
            return result;
        }

    }
}


