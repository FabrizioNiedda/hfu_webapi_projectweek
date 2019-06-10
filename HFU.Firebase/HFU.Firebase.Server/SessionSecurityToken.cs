using System;
using Microsoft.IdentityModel.Tokens;

namespace HFU.Firebase.Server
{
    public class SessionSecurityToken : SecurityToken
    {
        public SessionSecurityToken(string id)
        {
            Id = id;
        }
        
        public override string Id { get; }

        public override string Issuer { get; } = "HFU";

        public override SecurityKey SecurityKey { get; } = null;

        public override SecurityKey SigningKey { get; set; } = null;
        
        public override DateTime ValidFrom { get; } = DateTime.MinValue;
        
        public override DateTime ValidTo { get; } = DateTime.MaxValue;
    }
}