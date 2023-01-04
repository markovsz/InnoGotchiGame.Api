using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using Domain.Interfaces.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetsService _petsService;
        private IValidationHelper<PetCreatingDto> _petCreatingDtoValidator;
        private IValidationHelper<PetUpdatingDto> _petUpdatingDtoValidator;

        public PetsController(IPetsService petsService, IValidationHelper<PetCreatingDto> petCreatingDtoValidator, IValidationHelper<PetUpdatingDto> petUpdatingDtoValidator)
        {
            _petsService = petsService;
            _petCreatingDtoValidator = petCreatingDtoValidator;
            _petUpdatingDtoValidator = petUpdatingDtoValidator;
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost]
        public async Task<IActionResult> CreatePetAsync([FromBody] PetCreatingDto petDto, Guid userId)
        {
            await _petCreatingDtoValidator.ValidateAsync(petDto);
            var petId = await _petsService.CreatePetAsync(petDto, userId);
            return Created($"{petId}", new { Id = petId });
        }

        [Authorize]
        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetPetByIdAsync(Guid petId)
        {
            var petDto = await _petsService.GetPetByIdAsync(petId);
            return Ok(petDto);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPetsAsync(Guid userId)
        {
            var petDto = await _petsService.GetUserPetsAsync(userId);
            return Ok(petDto);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetPetsAsync([FromQuery] PetParameters parameters)
        {
            var pets = await _petsService.GetPetsAsync(parameters);

            Response.Headers.Add("X-Pagination-Page-Count", JsonConvert.SerializeObject(pets.PagesCount));
            return Ok(pets.Pets);
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("pet/{petId}/feed")]
        public async Task<IActionResult> FeedPetAsync(Guid petId, Guid userId)
        {
            var currentHungerLevel = await _petsService.FeedPetAsync(petId, userId);
            return Ok(Content(currentHungerLevel));
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("pet/{petId}/give-drink")]
        public async Task<IActionResult> QuenchPetThirstAsync(Guid petId, Guid userId)
        {
            var currentThirstLevel = await _petsService.QuenchPetThirstAsync(petId, userId);
            return Ok(Content(currentThirstLevel));
        }

        [Authorize]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPut("pet")]
        public async Task<IActionResult> UpdatePetAsync([FromBody] PetUpdatingDto petDto, Guid userId)
        {
            await _petUpdatingDtoValidator.ValidateAsync(petDto);
            await _petsService.UpdatePetAsync(petDto, userId);
            return NoContent();
        }
    }
}
