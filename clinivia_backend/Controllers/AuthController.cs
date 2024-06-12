using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinivia_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // Vous devez vérifier les informations d'identification ici (par exemple, vérifier dans la base de données)
            if (loginDto.Username == "amine" && loginDto.Password == "1234") // C'est un exemple, vous devriez vérifier les informations d'identification réelles
            {
                var token = _tokenService.GenerateToken(loginDto.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
