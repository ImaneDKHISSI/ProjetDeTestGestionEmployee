using Microsoft.IdentityModel.Tokens;
using ProjetTest.Data;
using ProjetTest.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetTest.Services.Implementations
{
    public class AuthService
    {
        private readonly MyContext db;
        private readonly IConfiguration config;

        public AuthService(MyContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var employe = db.Employes.FirstOrDefault(e => e.email == dto.email);
            if (employe == null) return null;

            // Vérification du mot de passe
            bool isValid = BCrypt.Net.BCrypt.Verify(dto.password, employe.password);
            if (!isValid) return null;

            // Création du token JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employe.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, employe.email),
                new Claim("name", employe.firstName + " " + employe.lastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
