using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.Token;
using MyMovies.Entities;

namespace MyMovies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly GenerateToken _generateToken;

        public LoginController(GenerateToken generateToken)
        {
            _generateToken = generateToken;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Authenticate authInfo)
        {
            var token = await _generateToken.GenerateJwt(authInfo);
            if(token == null)
            {
                return NotFound(new { Message = "Usuário ou senha Inválidos" });
            }
            return Ok(new { Token = token });
        }
    }
}
