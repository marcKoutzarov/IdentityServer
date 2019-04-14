using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel.Client;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;

namespace TestClient
{
   static class Program
    {

        static IDiscoveryCache _discoCache = new DiscoveryCache("https://localhost:5001");

        private static void Main()
        {
            Console.WriteLine("TestClient; Press Key to continue....");
            Console.ReadKey();
            Console.WriteLine("running....");


            
         //   var client = new HttpClient();
                     

            TokenResponse tokenResponse;
            IntrospectionResponse IntroSpectionResponse;


        AuthenticateClient1:

            //---------------------------------------------------------
            Console.WriteLine("authenicate a  Client (1) with referance token");

            //tokenResponse = RequestClientCredentialsToken_Async("Client1", "Client1Secret").Result;
            tokenResponse = RequestPasswordToken_Async("Client1", "Client1Secret", "bob", "password").Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                Console.WriteLine(tokenResponse.Json);
                Console.WriteLine("Press Key to exit....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Client 1 referance token: \n\n");
                Console.WriteLine(tokenResponse.Json);
                Console.WriteLine("\n\n");
                Console.WriteLine("making a IntrospectTokenRequest to get claims");

            checkToken:
                IntroSpectionResponse = IntrospectToken_Async(tokenResponse.AccessToken).Result;
                Console.WriteLine(IntroSpectionResponse.Json);
                Console.WriteLine("\n\n");
                Console.WriteLine("Press C to Validate the Token.");
                Console.WriteLine("Press A to get new Access Token.");
                ConsoleKeyInfo K = Console.ReadKey();

                if (K.Key == ConsoleKey.C)
                {

                    goto checkToken;

                }
                else if (K.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    goto AuthenticateClient1;
                }
            }
           
           

           
           
          


            ////---------------------------------------------------------
            //Console.WriteLine("authenicate a  Client (2) with JWT token");
            //tokenResponse = RequestClientCredentialsToken_Async("Client2", "Client2Secret").Result;
            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    Console.WriteLine("Press Key to exit....");
            //    Console.ReadKey();
            //}
            //Console.WriteLine("Client 2 token \n\n");
            //Console.WriteLine(tokenResponse.Json);
            //Console.WriteLine("\n\n");
            //// decode the token
            //decodeToken(tokenResponse.AccessToken);

            //Console.ReadKey();




            //Console.WriteLine("\n\n");
            //Console.WriteLine("Lets Authencate BOB");
            ////---------------------------------------------------------
            //// authenicate a USER BOB using Client (2)
            //tokenResponse = RequestPasswordToken_Async("Client1", "Client1Secret", "bob", "password").Result;
            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    Console.WriteLine("Press Key to exit....");
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine("Bobs using client 2 token \n\n");
            //Console.WriteLine(tokenResponse.Json);
            // decodeToken(tokenResponse.AccessToken);

            Console.WriteLine("\n\n");
            Console.ReadKey();
        }


        private static void decodeToken(string t)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(t) as JwtSecurityToken;

            var claims = tokenS.Claims;

            foreach (Claim c in claims)
            {
                Console.WriteLine(c.Type + " : "+ c.Value);
            }
           
        }


        private static string CreateHashedPasword(string password, string salt)
        {
            var StrToHash = password + salt;

            var result = new Secret(StrToHash.ToSha512());

            return result.Value;

        }






        /// <summary>
        /// Login as a USER (bob) using client 1 returns a JTW token
        /// </summary>
        /// <returns></returns>
        private static async Task<TokenResponse> RequestPasswordToken_Async(string clientName, string ClientSecret, string userName, string passWord)
        {
            var disco = await _discoCache.GetAsync();
            if (disco.IsError) throw new Exception(disco.Error);

            var client = new HttpClient();
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = clientName,
                ClientSecret = ClientSecret,
                UserName = userName,
                Password = passWord
            });

            return response;
        }



        /// <summary>
        /// Login as a client (Client2) (returns a referance token)
        /// </summary>
        /// <returns></returns>
        private static async Task<TokenResponse> RequestClientCredentialsToken_Async(string clientName, string ClientSecret)
        {
            var disco = await _discoCache.GetAsync();
            if (disco.IsError) throw new Exception(disco.Error);

            var client = new HttpClient();
            // request token 
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientName,
                ClientSecret = ClientSecret,
            });


            return response;
        }


        /// <summary>
        /// Login as a client (Client2) (returns a referance token)
        /// </summary>
        /// <returns></returns>
        private static async Task<IntrospectionResponse> IntrospectToken_Async(string refToken)
        {
            var disco = await _discoCache.GetAsync();
            if (disco.IsError) throw new Exception(disco.Error);

            var client = new HttpClient();

            var result = await client.IntrospectTokenAsync(new TokenIntrospectionRequest
            {
                Address = disco.IntrospectionEndpoint,
                ClientId = "api3",
                ClientSecret = "Api3Secret",
                Token = refToken
            });

            return await Task<IntrospectionResponse>.FromResult(result);
         
        }






    }
}
