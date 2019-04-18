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
        public async Task<IActionResult> GetRefTokenAsync()
        {
            ReferenceTokenModel result = new ReferenceTokenModel();

            IDiscoveryCache _discoCache = new DiscoveryCache("https://localhost:5001");
            var disco = await _discoCache.GetAsync();

            if (disco.IsError) {
                // throw new Exception(disco.Error);
                result.Result = disco.Error;

                return View(result);
            };

            var client = new HttpClient();
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "Client1",
                ClientSecret = "Client1Secret",
                UserName = "bob",
                Password = "password"
            });

            if (response.IsError)
            {
                result.Result = response.Json.ToString();
            }
            else
            {
                result.Result = response.Json.ToString();
            }

            return View(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}