using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
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

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreatingDto userDto)
        {
            var userId = await _usersService.CreateUserAsync(userDto);
            return Created($"{userId}", new { Id = userId});
        }

        [Authorize]
        [HttpGet("{userId}", Name = "GetUserInfo")]
        public async Task<IActionResult> GetUserInfoByIdAsync(Guid userId)
        {
            var userInfo = await _usersService.GetUserInfoByIdAsync(userId);
            return Ok(userInfo);
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
            await _usersService.ChangePasswordAsync(userId, passwordChangingDto);
            return NoContent();
        }
    }
}
