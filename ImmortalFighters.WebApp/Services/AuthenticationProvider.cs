using ImmortalFighters.WebApp.Models;
using ImmortalFighters.WebApp.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImmortalFighters.WebApp.Services
{
    public class ClaimTypes
    {
        public static string Id = "id";
        public static string RoleId = "roleId";
        public static string RoleName = "roleName";
    }

    public interface IAuthenticationProvider
    {
        string GetToken(User user);
        IEnumerable<Claim> ValidateToken(string token);
    }

    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly SecurityOptions _securityOptions;

        public AuthenticationProvider(IOptions<SecurityOptions> options)
        {
            _securityOptions = options.Value;
        }

        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_securityOptions.Secret);

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Id, user.UserId.ToString()));
            foreach(var userRole in user.UserRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.RoleId, userRole.RoleId.ToString()));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.RoleName, userRole.Role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.Add(_securityOptions.TokenExpirationTimeout),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<Claim> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_securityOptions.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims;
        }
    }
}
