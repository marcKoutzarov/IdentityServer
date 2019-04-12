using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityHostSvr.Controllers
{
    [Route("api/Authorizations")]
    public class LoginControler : ControllerBase
    {
       private IDiscoveryCache _discoCache;
       private string RootUrl;


        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "Hi are you ready to login ?";
        }

       /// <summary>
       /// Get a JWT token wirh claims
       /// </summary>
       /// <param name="credentials">Username and Password</param>
       /// <returns>a Token</returns>
        [HttpPost]
        public string Post([FromBody]UserCredentials credentials)
        {
            if (Request.IsHttps)
            {
                RootUrl = "https://" + Request.Host.Host + ":" + Request.Host.Port;
               _discoCache = new DiscoveryCache(RootUrl);
            }
            else {
                RootUrl = "http://" + Request.Host.Host + ":" + Request.Host.Port;
               _discoCache = new DiscoveryCache(RootUrl);
            };

            TokenResponse result = RequestPasswordToken_Async("Client1", "Client1Secret", credentials.username, credentials.password).Result;

            if (result.IsError)
            {
                Response.StatusCode = 401;
                return "";
            }
            else
            {
                Response.StatusCode =200;
                return result.Json.ToString(); 
            }
        }


        /// <summary>
        /// Login as a USER (bob) using client 1 returns a JTW token
        /// </summary>
        /// <returns></returns>
        private async Task<TokenResponse> RequestPasswordToken_Async(string clientName, string ClientSecret, string userName, string passWord)
        {
          

            var disco = await _discoCache.GetAsync();
            if (disco.IsError) throw new Exception(disco.Error);

            var client = new HttpClient();
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientName,
                ClientSecret = ClientSecret,
                Scope = "api1",
                UserName = userName,
                Password = passWord
            });

            return response;
        }

        public class UserCredentials
        {
            public string username { get; set; }
            public string password { get; set; }
        }

    }
}
