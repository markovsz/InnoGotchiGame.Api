using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
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
    public class FarmsController : ControllerBase
    {
        private IFarmsService _farmsService;

        public FarmsController(IFarmsService farmsService)
        {
            _farmsService = farmsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFarmAsync(Guid userId, [FromBody] FarmCreatingDto farmDto)
        {
            var farmId = await _farmsService.CreateFarmAsync(userId, farmDto);
            return Created($"{farmId}", new { Id = farmId });
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFarmByUserIdAsync(Guid userId)
        {
            var farmDto = await _farmsService.GetFarmByUserIdAsync(userId);
            return Ok(farmDto);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("friends")]
        public async Task<IActionResult> GetFriendFarmsAsync(Guid userId)
        {
            var farms = await _farmsService.GetFriendFarmsAsync(userId);
            return Ok(farms);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetFarmsAsync()
        {
            var farms = await _farmsService.GetFarmsAsync();
            return Ok(farms);
        }

        [Authorize]
        [HttpPut("farm")]
        public async Task<IActionResult> UpdateFarmAsync([FromBody] FarmUpdatingDto farmDto, Guid userId)
        {
            await _farmsService.UpdateFarmAsync(farmDto, userId);
            return NoContent();
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpDelete("farm")]
        public async Task<IActionResult> DeleteFarmByUserIdAsync(Guid userId)
        {
            await _farmsService.DeleteFarmByUserIdAsync(userId);
            return NoContent();
        }
    }
}
