﻿using Application.Services.DataTransferObjects.Creating;
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
    public class FarmsController : ControllerBase
    {
        private IFarmsService _farmsService;
        private IValidationHelper<FarmCreatingDto> _farmCreatingDtoValidator;
        private IValidationHelper<FarmUpdatingDto> _farmUpdatingDtoValidator;

        public FarmsController(IFarmsService farmsService, IValidationHelper<FarmCreatingDto> farmCreatingDtoValidator, IValidationHelper<FarmUpdatingDto> farmUpdatingDtoValidator)
        {
            _farmsService = farmsService;
            _farmCreatingDtoValidator = farmCreatingDtoValidator;
            _farmUpdatingDtoValidator = farmUpdatingDtoValidator;
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateFarmAsync(Guid userId, [FromBody] FarmCreatingDto farmDto)
        {
            await _farmCreatingDtoValidator.ValidateAsync(farmDto);
            var farmId = await _farmsService.CreateFarmAsync(userId, farmDto);
            return Created($"{farmId}", new { Id = farmId });
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("farm/{farmId}")]
        public async Task<IActionResult> GetFarmByIdAsync(Guid farmId, Guid userId)
        {
            var farmDto = await _farmsService.GetFarmByIdAsync(farmId, userId);
            return Ok(farmDto);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("my-farm")]
        public async Task<IActionResult> GetMyFarmAsync(Guid userId)
        {
            var farmDto = await _farmsService.GetMinFarmByUserIdAsync(userId);
            return Ok(farmDto);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("my-farm-details")]
        public async Task<IActionResult> GetMyFarmDetailsAsync(Guid userId)
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
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPut("farm")]
        public async Task<IActionResult> UpdateFarmAsync([FromBody] FarmUpdatingDto farmDto, Guid userId)
        {
            await _farmUpdatingDtoValidator.ValidateAsync(farmDto);
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
