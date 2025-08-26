using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetTest.Dto;
using ProjetTest.Services.Implementations;

namespace ProjetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await authService.Login(dto);
            if (token == null)
            {
                return Unauthorized("Email ou mot de passe invalide");
            }

            Response.Headers.Add("Authorization", "Bearer " + token);

            // Optionnel : tu peux aussi renvoyer un corps minimal
            return Ok(new { Message = "Connexion réussie" });
        }
    }
}

