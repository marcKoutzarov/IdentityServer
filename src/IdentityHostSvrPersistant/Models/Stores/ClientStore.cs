using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;

namespace IdentityHostSvr.Models.Stores
{
    public class ClientStore : IClientStore
    {

        /// <summary>
        /// Implement 
        /// </summary>
        /// <param name="clientId">The Client ID</param>
        /// <returns></returns>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var Clients = ClientsConfig.GetClients();

            Client Result= null;

            foreach (Client c in Clients)
            {
                 if (c.ClientId == clientId)
                {
                    Result = c;
                    return Task.FromResult<Client>(Result);
                }
            }

            return Task.FromResult<Client>(Result);
        }
    }
}
