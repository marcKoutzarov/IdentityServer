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
    /// <summary>
    /// Generated a new Sha516 password
    /// </summary>
    [Route("api/PasswordGenerator")]
    public class PasswordGeneratorController : ControllerBase
    {
     
       /// <summary>
       /// 
       /// </summary>
       /// <param name="cred">password and optional a salt</param>
       /// <returns>Hashed password</returns>
        [HttpGet]
        public string Get(UserCredentials cred)
        {
            return "Hi are you ready to login ?";
        }
  
        public class UserCredentials
        {
            public string Salt { get; set; }
            public string Password { get; set; }
        }
    }
}
