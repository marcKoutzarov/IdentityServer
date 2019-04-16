using IdentitySvr.Interfaces.Repositories;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentitySvr.Entities.Mappers;
using IdentitySvr.Entities.Pocos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentitySvr.Host.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IResourcesRepo _repo;

        public ClientStore(IResourcesRepo repo)
        {
            _repo = repo;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var poco = _repo.FindClientByUsernameAsync(clientId).Result;

            return Task.FromResult(ClientMapper.Map(poco));
        }
    }
}
