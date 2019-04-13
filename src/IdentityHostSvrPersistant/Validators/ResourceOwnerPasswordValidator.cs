using IdentityHostSvr.Interfaces.Stores;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Threading.Tasks;


namespace IdentityHostSvr.Models.Validators
{
    public class ResourceOwnerPasswordValidator:IResourceOwnerPasswordValidator
    {

        //Use the Store to get users
        private readonly IUserStore _userRepository;

        public ResourceOwnerPasswordValidator(IUserStore userStore)
        {
            _userRepository = userStore; //DI
        }

        //this is used to validate your user account with provided grant at /connect/token
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                //get your user model from db (by username - in my case its email)
                var user = _userRepository.GetUser(context.UserName);


                if (user != null)
                {
                    //check if password match - remember to hash password if stored as hash in db
                    if (user.Password == context.Password)
                    {
                        //set the result
                        context.Result = new GrantValidationResult(
                           subject: user.SubjectId.ToString(),
                           authenticationMethod: "custom",
                           claims:user.Claims);
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
        
    }
}
