using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityServer4.Stores;
using IIdentityHostSvr.Repositories.Mock;
using IdentityHostSvr.Interfaces.Repositories;

namespace IdentityHostSvr.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IResourcesRepo _repo;

        public ClientStore(IResourcesRepo repo)
        {
            _repo = repo;
        }


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
