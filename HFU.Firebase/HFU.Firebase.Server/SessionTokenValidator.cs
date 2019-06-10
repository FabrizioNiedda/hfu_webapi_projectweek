using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace HFU.Firebase.Server
{
    public class SessionTokenValidator : ISecurityTokenValidator
    {
        public bool CanReadToken(string securityToken) => true;

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            validatedToken = null;
            
            // TODO Validate the token against the database.
            if (securityToken == "1234")
            {
                validatedToken = new SessionSecurityToken(securityToken);
                
                // TODO Parse out username and claims via the database.
                return new ClaimsPrincipal(new GenericIdentity("HFU"));    
            }

            return new ClaimsPrincipal(new GenericIdentity(""));
        }

        public bool CanValidateToken { get; } = true;

        public int MaximumTokenSizeInBytes { get; set; } = int.MaxValue;
    }
}