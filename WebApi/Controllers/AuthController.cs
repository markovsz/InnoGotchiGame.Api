using Application.Services.DataTransferObjects;
using Application.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignInAsync(UserAuthenticationDto authDto)
        {
            var accessDto = await _authService.SignInAsync(authDto);
            return Ok(accessDto);
        }
    }
}
