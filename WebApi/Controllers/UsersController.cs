using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        private IPicturesService _picturesService;
        private IValidationHelper<UserCreatingDto> _userCreatingDtoValidator;
        private IValidationHelper<UserUpdatingDto> _userUpdatingDtoValidator;
        private IValidationHelper<PasswordChangingDto> _passwordChangingDtoValidator;

        public UsersController(IUsersService usersService, IPicturesService picturesService, IValidationHelper<UserCreatingDto> userCreatingDtoValidator, IValidationHelper<UserUpdatingDto> userUpdatingDtoValidator, IValidationHelper<PasswordChangingDto> passwordChangingDtoValidator)
        {
            _usersService = usersService;
            _picturesService = picturesService;
            _userCreatingDtoValidator = userCreatingDtoValidator;
            _userUpdatingDtoValidator = userUpdatingDtoValidator;
            _passwordChangingDtoValidator = passwordChangingDtoValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreatingDto userDto)
        {
            await _userCreatingDtoValidator.ValidateAsync(userDto);
            var userId = await _usersService.CreateUserAsync(userDto);
            return Created($"{userId}", new { Id = userId});
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("my-profile")]
        public async Task<IActionResult> GetMyProfileDetailsAsync(Guid userId)
        {
            var userInfo = await _usersService.GetUserInfoByIdAsync(userId);
            return Ok(userInfo);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("my-profile/min")]
        public async Task<IActionResult> GetMyMinProfileDetailsAsync(Guid userId)
        {
            var userInfo = await _usersService.GetMinUserInfoByIdAsync(userId);
            return Ok(userInfo);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPut("my-profile")]
        public async Task<IActionResult> UpdateUserByIdAsync(Guid userId, [FromBody] UserUpdatingDto userDto)
        {
            await _userUpdatingDtoValidator.ValidateAsync(userDto);
            await _usersService.UpdateUserAsync(userId, userDto);
            return NoContent();
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid userId)
        {
            await _usersService.DeleteUserByIdAsync(userId);
            return NoContent();
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPut("my-profile/new-password")]
        public async Task<IActionResult> ChangePasswordAsync(Guid userId, [FromBody] PasswordChangingDto passwordChangingDto)
        {
            await _passwordChangingDtoValidator.ValidateAsync(passwordChangingDto);
            await _usersService.ChangePasswordAsync(userId, passwordChangingDto);
            return NoContent();
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("my-profile/avatar")]
        public async Task<IActionResult> CreateAvatar(Guid userId, [FromBody] string pictureBase64)
        {
            var pictureName = _picturesService.CreatePicture(pictureBase64);
            await _usersService.UpdateUserAvatarAsync(userId, pictureName);
            return Created($"/images/{pictureName}", pictureName);
        }
    }
}
