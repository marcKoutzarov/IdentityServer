using IdentityHostSvr.Repositories.pocos;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityHostSvr.Repositories.InMemoryData
{
    public static class ClientsData
    {
      
        public static ClientPoco GetClients(string ClientID)
        {           
            ClientPoco g = null;
            g = GetClients().FirstOrDefault(c => c.ClientUserName== ClientID);
            return g;
        }

        public static IEnumerable<ClientPoco> GetClients()
        {
            return new List<ClientPoco>
            {
                new ClientPoco {
                    Id=1,
                    ClientUserName ="",
                    AccessTokenLifeTime =0,
                    AccessTokenType ="",
                    Description ="",
                    Enabled =true,
                    Role ="",
                    Secret ="",
                    ApiScopes = new List<ScopePoco> {
                        new ScopePoco{Id=1,  Api="", Scope=""},
                        new ScopePoco{Id=2,  Api="", Scope=""}
                    }
                },
                new ClientPoco {
                    Id=1,
                    ClientUserName ="",
                    AccessTokenLifeTime =0,
                    AccessTokenType ="",
                    Description ="",
                    Enabled =true,
                    Role ="",
                    Secret ="",
                    ApiScopes = new List<ScopePoco> {
                        new ScopePoco{Id=1,  Api="", Scope=""},
                        new ScopePoco{Id=2,  Api="", Scope=""}
                    }
                },
                new ClientPoco {
                    Id=1,
                    ClientUserName ="",
                    AccessTokenLifeTime =0,
                    AccessTokenType ="",
                    Description ="",
                    Enabled =true,
                    Role ="",
                    Secret ="",
                    ApiScopes = new List<ScopePoco> {
                        new ScopePoco{Id=1,  Api="", Scope=""},
                        new ScopePoco{Id=2,  Api="", Scope=""}
                    }
                }
            };
        }


    }
}
