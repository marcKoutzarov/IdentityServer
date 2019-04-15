using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentitySvr.Host.Controllers
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
