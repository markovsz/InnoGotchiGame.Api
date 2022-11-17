using Application.Services.DataTransferObjects.Creating;
using Application.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmFriendsController : ControllerBase
    {
        private IFarmFriendsService _farmFriendsService;

        public FarmFriendsController(IFarmFriendsService farmFriendsService)
        {
            _farmFriendsService = farmFriendsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarmFriendAsync([FromBody] FarmFriendCreatingDto farmDto)
        {
            var farmFriendId = await _farmFriendsService.CreateFarmFriendAsync(farmDto);
            return Created($"{farmFriendId}", new { Id = farmFriendId });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserFarmFriendsAsync(Guid userId)
        {
            var farmFriends = await _farmFriendsService.GetUserFarmFriendsAsync(userId);
            return Ok(farmFriends);
        }

        [HttpDelete("user/{userId}")]
        public async Task<IActionResult> DeleteFarmFriendByIdAsync(Guid userId)
        {
            await _farmFriendsService.DeleteFarmFriendByIdAsync(userId);
            return NoContent();
        }
    }
}
