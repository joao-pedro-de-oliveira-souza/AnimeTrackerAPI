using AnimeTracker.Dtos;
using AnimeTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAnimes()
        {
            var animeDtos = await _animeService.GetAllAnimes();
            return Ok(animeDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnime(int id)
        {
            var animeDto = await _animeService.GetAnime(id);
            if (animeDto == null)
                return NotFound("Anime not found.");

            return Ok(animeDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnime(AnimeDto animeDto)
        {
            var newAnime = await _animeService.AddAnime(animeDto);
            return CreatedAtAction(nameof(GetAnime), new { id = newAnime.Id }, newAnime);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime(int id, AnimeDto updateDto)
        {
            var result = await _animeService.UpdateAnime(id, updateDto);
            if (!result)
                return NotFound("Anime not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            var result = await _animeService.DeleteAnime(id);
            if (!result)
                return NotFound("Anime not found.");

            return Ok(await _animeService.GetAllAnimes());
        }
    }
}
