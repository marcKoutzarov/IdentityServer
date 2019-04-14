using IdentityHostSvr.Interfaces.Stores;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace IdentityHostSvr.Models.Validators
{
    public class ResourceOwnerPasswordValidator:IResourceOwnerPasswordValidator
    {

        //Use the Store to get users
        private readonly IUserStore _userStore;

        public ResourceOwnerPasswordValidator(IUserStore userStore)
        {
            _userStore = userStore; //DI
        }

        //this is used to validate your user account with provided grant at /connect/token
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                //get your user model from db (by username - in my case its email)
                var user = _userStore.GetUser(context.UserName);
               

                if (user != null)
                {
                    // check if this user can access this client.
                    if (!String.IsNullOrEmpty(user.AllowedClients))
                    {
                        string[] AllowedClients = user.AllowedClients.Split(";");
                        var cN = AllowedClients.FirstOrDefault(c => c == context.Request.Client.ClientId);

                        if (cN.Length == 0)
                        {
                            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Client Access denied for: " + context.Request.Client.ClientId);
                            return;
                        }

                    }
                    else {
                      context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Client Access denied for: " + context.Request.Client.ClientId);
                      return;
                    }
                   



                    //check if password match
                    if (user.Password == CreateHashedPasword(context.Password, user.Salt))
                    {
                        //set the result
                        context.Result = new GrantValidationResult(
                           subject: user.SubjectId.ToString(),
                           authenticationMethod: "custom",
                           claims:user.Claims
                           );
                           return;
                    }

                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                    return;
                }

                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                return;
            }

            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
                return; //i added this
            }

        }

        private static string CreateHashedPasword(string password, string salt)
        {
            var StrToHash = password + salt;

            var result = new Secret(StrToHash.Sha512());

            return result.Value;
        }
    }
}
