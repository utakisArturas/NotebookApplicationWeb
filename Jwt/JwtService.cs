using Microsoft.IdentityModel.Tokens;
using NotebookApplicationWeb.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NotebookApplicationWeb.Jwt
{
    public class JwtService :IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtToken(string username)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username)
            };
            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44360/",
                audience: "https://localhost:44360/",
                claims: claims,
                expires: System.DateTime.Now.AddDays(1),
                signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
