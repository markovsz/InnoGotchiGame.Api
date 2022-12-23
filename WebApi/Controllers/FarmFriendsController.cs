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
    public class FarmFriendsController : ControllerBase
    {
        private IFarmFriendsService _farmFriendsService;

        public FarmFriendsController(IFarmFriendsService farmFriendsService)
        {
            _farmFriendsService = farmFriendsService;
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateFarmFriendAsync([FromBody] FarmFriendCreatingDto farmDto, Guid userId)
        {
            var farmFriendId = await _farmFriendsService.CreateFarmFriendAsync(farmDto, userId);
            return Created($"{farmFriendId}", new { Id = farmFriendId });
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpDelete("farm-friend/{farmFriendId}")]
        public async Task<IActionResult> DeleteFarmFriendByIdAsync(Guid farmFriendId, Guid userId)
        {
            await _farmFriendsService.DeleteFarmFriendByIdAsync(farmFriendId, userId);
            return NoContent();
        }
    }
}
