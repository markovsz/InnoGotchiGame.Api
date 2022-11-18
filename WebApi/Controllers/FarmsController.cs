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
        [HttpPut]
        public async Task<IActionResult> UpdateFarmAsync([FromBody] FarmUpdatingDto farmDto)
        {
            await _farmsService.UpdateFarmAsync(farmDto);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("farm/{farmId}")]
        public async Task<IActionResult> DeleteFarmByIdAsync(Guid farmId)
        {
            await _farmsService.DeleteFarmByIdAsync(farmId);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("user/{userId}")]
        public async Task<IActionResult> DeleteFarmByUserIdAsync(Guid userId)
        {
            await _farmsService.DeleteFarmByUserIdAsync(userId);
            return NoContent();
        }
    }
}
