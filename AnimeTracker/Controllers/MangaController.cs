using AnimeTracker.Dtos;
using AnimeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IMangaService _mangaService;

        public MangaController(IMangaService mangaService)
        {
            _mangaService = mangaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMangas()
        {
            var mangaDtos = await _mangaService.GetAllMangas();
            return Ok(mangaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManga(int id)
        {
            var mangaDto = await _mangaService.GetManga(id);
            if (mangaDto == null)
                return NotFound("Manga not found.");

            return Ok(mangaDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddManga(MangaDto mangaDto)
        {
            var newManga = await _mangaService.AddManga(mangaDto);
            return CreatedAtAction(nameof(GetManga), new { id = newManga.Id }, newManga);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManga(int id, MangaDto updateDto)
        {
            var result = await _mangaService.UpdateManga(id, updateDto);
            if (!result)
                return NotFound("Manga not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManga(int id)
        {
            var result = await _mangaService.DeleteManga(id);
            if (!result)
                return NotFound("Manga not found.");

            return Ok(await _mangaService.GetAllMangas());
        }
    }
}
