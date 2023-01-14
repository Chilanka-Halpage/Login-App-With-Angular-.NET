using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAPI.Services
{
    public class JwtService
    {
        public string Key { get; set; }
        public int Duration { get; set; }

        public JwtService(IConfiguration configuration)
        {
            
            Key = configuration.GetValue<string>("JwtConfig:Key");
            Duration = configuration.GetValue<int>("JwtConfig:Duration");
        }

        public string GenerateToken(string email)
        {            
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var Signature = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var PayLoad = new[]
            {
                new Claim("id", email)
            };

            var JwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: PayLoad,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Duration),
                signingCredentials: Signature
                );

            return new JwtSecurityTokenHandler().WriteToken(JwtToken);
        }
    }
}
