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
    public class BodyPartsController : ControllerBase
    {
        private IBodyPartsService _bodyPartsService;

        public BodyPartsController(IBodyPartsService bodyPartsService)
        {
            _bodyPartsService = bodyPartsService;
        }

        [HttpGet("bodies")]
        public async Task<IActionResult> GetPetBodiesAsync()
        {
            var bodies = await _bodyPartsService.GetPetBodiesAsync();
            return Ok(bodies);
        }

        [HttpGet("eyes")]
        public async Task<IActionResult> GetPetEyesAsync()
        {
            var eyes = await _bodyPartsService.GetPetEyesAsync();
            return Ok(eyes);
        }

        [HttpGet("mouths")]
        public async Task<IActionResult> GetPetMouthsAsync()
        {
            var mouth = await _bodyPartsService.GetPetMouthsAsync();
            return Ok(mouth);
        }

        [HttpGet("noses")]
        public async Task<IActionResult> GetPetNosesAsync()
        {
            var noses = await _bodyPartsService.GetPetNosesAsync();
            return Ok(noses);
        }
    }
}
