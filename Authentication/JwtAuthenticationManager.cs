using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace heinousHorror.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManger
    {
        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            // Create security token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //Create a key to encrypt the token
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //Get the token descriptor to define the identity claim
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                //sign the token
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            //Get the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}