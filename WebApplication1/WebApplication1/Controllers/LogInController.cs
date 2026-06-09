using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EmployeeDetailesFunctionalService;
using WebApplication1.FunctionalService;
using WebApplication1.ObjectModel;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerateService tokenService;

        public AuthController(
            ITokenGenerateService tokenService)
        {
            tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            // Validate user from DB

            if (dto.UserName == "admin"
               && dto.Password == "123")
            {
                var token =
                    tokenService
                    .GenerateToken(dto.UserName);

                return Ok(new
                {
                    Token = token
                });
            }

            return Unauthorized();
        }
    }
}
