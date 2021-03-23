using Core.Entities.Concrete;
using Core.Extentions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentinals = SigningCredentinalsHelper.CreateSigningCredentinals(securityKey);
            var jwt = CreateJwtSecurityToken(user, operationClaims, signingCredentinals, _tokenOptions);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, List<OperationClaim> operationClaims,
            SigningCredentials signingCredentinals, TokenOptions tokenOptions)
        {
            var jwt = new JwtSecurityToken
                (
                    issuer : _tokenOptions.Issuer,
                    audience : _tokenOptions.Audience,
                    notBefore: DateTime.Now,
                    expires : _accessTokenExpiration,
                    claims : GetClaims(user,operationClaims),
                    signingCredentials : signingCredentinals
                );
            return jwt;
        }

        private IEnumerable<Claim> GetClaims(User user , List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(Convert.ToString(user.Id));
            claims.AddRoles(operationClaims.Select(c => c.ClaimName).ToArray());
            return claims;
        }
    }
}
