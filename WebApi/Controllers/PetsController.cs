using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
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
    public class PetsController : ControllerBase
    {
        private IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetAsync([FromBody] PetCreatingDto petDto)
        {
            var petId = await _petsService.CreatePetAsync(petDto);
            return Created($"{petId}", new { Id = petId });
        }

        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetPetByIdAsync(Guid petId)
        {
            var petDto = await _petsService.GetPetByIdAsync(petId);
            return Ok(petDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPetsAsync(Guid userId)
        {
            var petDto = await _petsService.GetUserPetsAsync(userId);
            return Ok(petDto);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPetsAsync()
        {
            var pets = await _petsService.GetPetsAsync();
            return Ok(pets);
        }

        [HttpPost("pet/{petId}/feed")]
        public async Task<IActionResult> FeedPetAsync(Guid petId)
        {
            await _petsService.FeedPetAsync(petId);
            return NoContent();
        }

        [HttpPost("pet/{petId}/thristQuenching")] //TODO: change it's address
        public async Task<IActionResult> QuenchPetThirstAsync(Guid petId)
        {
            await _petsService.QuenchPetThirstAsync(petId);
            return NoContent();
        }

        [HttpPut("pet/{petId}")]
        public async Task<IActionResult> UpdatePetAsync(Guid petId, [FromBody] PetUpdatingDto petDto)
        {
            await _petsService.UpdatePetAsync(petId, petDto);
            return NoContent();
        }
    }
}
