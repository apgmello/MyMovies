using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using MyMovies.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyMovies.Api.Token
{
    public class GenerateToken
    {
        private readonly Authenticate _authenticate;
        private readonly TokenConfiguration _configuration;

        public GenerateToken(TokenConfiguration configuration, Authenticate authenticate)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        public async Task<string> GenerateJwt(Authenticate authenticate)
        {
            return await Task.FromResult(((Func<string>)(()  =>  
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.Secret));
                var tokenHandler = new JwtSecurityTokenHandler();

                if (authenticate.Username != _authenticate.Username || authenticate.Password != _authenticate.Password)
                {
                    return null;
                }

                var subject = new Claim(JwtClaimTypes.Subject, _configuration.Subject);
                var module = new Claim("module", _configuration.Module);
                List<Claim> claims = new()
                {
                    subject,
                    module,
                };

                var jwtToken = new JwtSecurityToken(
                    issuer: _configuration.Issuer,
                    audience: _configuration.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(_configuration.ExpirationtimeInHours),
                    signingCredentials: new SigningCredentials(securityKey, "HS256"));


                return tokenHandler.WriteToken(jwtToken);
            }))());
        }
    }
}
