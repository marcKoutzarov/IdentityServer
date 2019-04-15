using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySvr.Repositories.InMemoryData
{
    public static class ResourceData
    {
      
        public static ClientPoco GetClients(string ClientID)
        {           
            ClientPoco g = null;
            g = GetClients().FirstOrDefault(c => c.ClientUserName== ClientID);
            return g;
        }


        public static IEnumerable<ApiResourcePoco> GetApiRecourceByScopesAsync(IEnumerable<string> scopeNames)
        {
            // need to implement scopenames filter later
            return GetApis();
        }


        public static ApiResourcePoco GetApis(string apiName)
        {
            ApiResourcePoco g = null;
            g = GetApis().FirstOrDefault(c => c.Name == apiName);
            return g;
        }










        public static IEnumerable<ClientPoco> GetClients()
        {
            return new List<ClientPoco>
            {
                new ClientPoco {
                    Id=1,
                    ClientUserName ="Client1",
                    Secret ="Client1Secret",
                    AccessTokenLifeTime =300,
                    AccessTokenType ="REF",
                    Description ="Description of Client 1",
                    Enabled =true,
                    Role ="frontend",
                    ApiScopes = new List<ClientScopePoco> {
                        new ClientScopePoco{ScopeId=1, Client="Client1",  Api="api1", Scope="api1.read"},
                        new ClientScopePoco{ScopeId=2, Client="Client1",  Api="api1", Scope="api1.insert"},
                        new ClientScopePoco{ScopeId=3, Client="Client1",  Api="api1", Scope="api1.update"},
                        new ClientScopePoco{ScopeId=4, Client="Client1",  Api="api2", Scope="api2.read"},
                        new ClientScopePoco{ScopeId=5, Client="Client1",  Api="api2", Scope="api2.insert"},
                        new ClientScopePoco{ScopeId=6, Client="Client1",  Api="api2", Scope="api2.update"},
                        //new ScopePoco{Id=7,  Api="api3", Scope="api3.read"},
                        //new ScopePoco{Id=8,  Api="api3", Scope="api3.insert"},
                        //new ScopePoco{Id=9,  Api="api3", Scope="api3.update"}
                    }
                },
                new ClientPoco {
                    Id=1,
                    ClientUserName ="Client2",
                    AccessTokenLifeTime =300,
                    AccessTokenType ="REF",
                    Description ="Description of Client 2",
                    Enabled =true,
                    Role ="api",
                    Secret ="Client2Secret",
                       ApiScopes = new List<ClientScopePoco> {
                        new ClientScopePoco{ScopeId=1, Client="Client2",  Api="api1", Scope="api1.read"},
                        new ClientScopePoco{ScopeId=4, Client="Client2",  Api="api2", Scope="api2.read"},
                        
                    }
                },
                new ClientPoco {
                    Id=1,
                    ClientUserName ="Client3",
                    AccessTokenLifeTime =300,
                    AccessTokenType ="REF",
                    Description ="Description of Client 3",
                    Enabled =true,
                    Role ="service",
                    Secret ="Client3Secret",
                        ApiScopes = new List<ClientScopePoco> {
                        new ClientScopePoco{ScopeId=4, Client="Client3",  Api="api2", Scope="api2.read"},
                        new ClientScopePoco{ScopeId=5, Client="Client3",  Api="api2", Scope="api2.insert"},
                        new ClientScopePoco{ScopeId=6, Client="Client3",  Api="api2", Scope="api2.update"},
                    }
                }
            };
        }

        public static IEnumerable<ApiResourcePoco> GetApis()
        {
            return new List<ApiResourcePoco>
            {
               new ApiResourcePoco {
                    Id =1,
                    ApiSecrets="Api1Secret",
                    Name ="api1",
                    DisplayName ="Display name of api 1",
                    Description ="Description of api 1",
                    Enabled =true,
                    ApiScopes = new List<ApiScopePoco> {
                        new ApiScopePoco{ScopeId=1,  Api="api1", Scope="api1.read"},
                        new ApiScopePoco{ScopeId=2,  Api="api1", Scope="api1.insert"},
                        new ApiScopePoco{ScopeId=3,  Api="api1", Scope="api1.update"}
                    },
                    UserClaims = new List<ClaimPoco>{
                        new ClaimPoco{ ClaimName="Name",Value=""},
                        new ClaimPoco{ ClaimName="Role",Value=""},
                        new ClaimPoco{ ClaimName="Email",Value=""},
                        new ClaimPoco{ ClaimName="Subject",Value=""}
                    }
                },
               new ApiResourcePoco {
                    Id =2,
                    ApiSecrets="Api2Secret",
                    Name ="api2",
                    DisplayName ="Display name of api 2",
                    Description ="Description of api 2",
                    Enabled =true,
                    ApiScopes = new List<ApiScopePoco> {
                        new ApiScopePoco{ScopeId=4,  Api="api2", Scope="api2.read"},
                        new ApiScopePoco{ScopeId=5,  Api="api2", Scope="api2.insert"},
                        new ApiScopePoco{ScopeId=6,  Api="api2", Scope="api2.update"}
                    },
                    UserClaims = new List<ClaimPoco>{
                        new ClaimPoco{ ClaimName="Name",Value=""},
                        new ClaimPoco{ ClaimName="Role",Value=""},
                        new ClaimPoco{ ClaimName="Email",Value=""},
                        new ClaimPoco{ ClaimName="Subject",Value=""}
                    }
                },
               new ApiResourcePoco {
                    Id =3,
                    ApiSecrets="Api3Secret",
                    Name ="api3",
                    DisplayName ="Display name of api 3",
                    Description ="Description of api 3",
                    Enabled =true,
                     ApiScopes = new List<ApiScopePoco> {
                        new ApiScopePoco{ScopeId=7,  Api="api3", Scope="api3.read"},
                        new ApiScopePoco{ScopeId=8,  Api="api3", Scope="api3.insert"},
                        new ApiScopePoco{ScopeId=9,  Api="api3", Scope="api3.update"}
                    },
                    UserClaims = new List<ClaimPoco>{
                        new ClaimPoco{ ClaimName="Name",Value=""},
                        new ClaimPoco{ ClaimName="Role",Value=""},
                        new ClaimPoco{ ClaimName="Email",Value=""},
                        new ClaimPoco{ ClaimName="Subject",Value=""}
                    }
                }
            };
        }

        public static IEnumerable<IdentityResourcesPoco> GetIdentityResources()
        {
            return new IdentityResourcesPoco[]{
               new IdentityResourcesPoco{
                    Name="OpenId Resouce",
                    IdentityResourceType= IdentityResourceType.OpenId,
                    UserClaims = new List<ClaimPoco>{
                        new ClaimPoco{ ClaimName="Name",Value=""},
                        new ClaimPoco{ ClaimName="Role",Value=""},
                        new ClaimPoco{ ClaimName="Email",Value=""},
                        new ClaimPoco{ ClaimName="Subject",Value=""}
                    }
               },
               new IdentityResourcesPoco{
                    Name="Profile Resource",
                    IdentityResourceType= IdentityResourceType.Profile,
                    UserClaims = new List<ClaimPoco>{
                        new ClaimPoco{ ClaimName="Name",Value=""},
                        new ClaimPoco{ ClaimName="Role",Value=""},
                        new ClaimPoco{ ClaimName="Email",Value=""},
                        new ClaimPoco{ ClaimName="Subject",Value=""}
                    }
               }

            };
        }

    }
}
