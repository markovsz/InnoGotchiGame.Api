using Application.Services.DataTransferObjects;
using Application.Services.Helpers;
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
        private IValidationHelper<UserAuthenticationDto> _userAuthenticationDtoValidator;

        public AuthController(IAuthService authService, IValidationHelper<UserAuthenticationDto> userAuthenticationDtoValidator)
        {
            _authService = authService;
            _userAuthenticationDtoValidator = userAuthenticationDtoValidator;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignInAsync(UserAuthenticationDto authDto)
        {
            await _userAuthenticationDtoValidator.ValidateAsync(authDto);
            var accessDto = await _authService.SignInAsync(authDto);
            return Ok(accessDto);
        }
    }
}
