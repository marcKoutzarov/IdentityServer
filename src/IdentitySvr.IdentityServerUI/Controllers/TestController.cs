using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentitySvr.IdentityServerUI.Models;
using IdentityModel.Client;
using System.Net.Http;

namespace IdentitySvr.IdentityServerUI.Controllers
{
    public class TestController : Controller
    {

        public IActionResult Test()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetRefTokenAsync(IdentityCredentialsModel model)
        {
           

            IDiscoveryCache _discoCache = new DiscoveryCache(model.IdentityServer);
            var disco = await _discoCache.GetAsync();

            if (disco.IsError) {
                // throw new Exception(disco.Error);
                model.ReferenceToken  = disco.Error;

                return View("ReferenceToken", model);
            };

            var client = new HttpClient();
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = model.ClientUserName,
                ClientSecret = model.ClientSecret,
                UserName = model.UserUserName,
                Password =model.UserSecret
            });

            if (response.IsError)
            {
                model.ReferenceToken = response.Json.ToString();
            }
            else
            {
                model.ReferenceToken = response.Json.ToString();
            }

            return View("ReferenceToken", model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetClaimsTokenAsync(IdentityCredentialsModel model)
        {

            IDiscoveryCache _discoCache = new DiscoveryCache(model.IdentityServer);

            var disco = await _discoCache.GetAsync();

            if (disco.IsError)
            {
                // throw new Exception(disco.Error);
                model.ClaimsToken = disco.Error;
                return View("ReferenceToken", model);
            };

            var client = new HttpClient();

            var response = await client.IntrospectTokenAsync(new TokenIntrospectionRequest
            {
                Address = disco.IntrospectionEndpoint,
                ClientId = model.ApiUserName,
                ClientSecret = model.ApiSecret, //"Api3Secret",
                Token = model.ReferenceToken
            });

           if (response.IsError)
            {
                model.ClaimsToken = response.Json.ToString();
            }
            else
            {
                model.ClaimsToken = response.Json.ToString();
            }

            return View("ReferenceToken", model);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}