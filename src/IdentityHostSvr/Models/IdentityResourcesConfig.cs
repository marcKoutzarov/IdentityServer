using IdentityServer4.Models;
using System.Collections.Generic;


namespace IdentityHostSvr.Models
{
    public static class IdentityResourcesConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
