using AnimeTracker.Dtos;
using AnimeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightNovelController : ControllerBase
    {
        private readonly ILightNovelService _lightNovelService;

        public LightNovelController(ILightNovelService lightNovelService)
        {
            _lightNovelService = lightNovelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLightNovels()
        {
            var lightNovelDtos = await _lightNovelService.GetAllLightNovels();
            return Ok(lightNovelDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLightNovel(int id)
        {
            var lightNovelDto = await _lightNovelService.GetLightNovel(id);
            if (lightNovelDto == null)
                return NotFound("Light Novel not found.");

            return Ok(lightNovelDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddLightNovel(LightNovelDto lightNovelDto)
        {
            var newLightNovel = await _lightNovelService.AddLightNovel(lightNovelDto);
            return CreatedAtAction(nameof(GetLightNovel), new { id = newLightNovel.Id }, newLightNovel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLightNovel(int id, LightNovelDto updateDto)
        {
            var result = await _lightNovelService.UpdateLightNovel(id, updateDto);
            if (!result)
                return NotFound("Light Novel not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLightNovel(int id)
        {
            var result = await _lightNovelService.DeleteLightNovel(id);
            if (!result)
                return NotFound("Light Novel not found.");

            return Ok(await _lightNovelService.GetAllLightNovels());
        }
    }
}
