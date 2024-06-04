// AnimeService.cs
using AnimeTracker.Data;
using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly DataContext _context;

        public AnimeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<AnimeDto>> GetAllAnimes()
        {
            var animes = await _context.Animes.ToListAsync();
            return animes.Select(anime => new AnimeDto
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                Rating = anime.Rating
            }).ToList();
        }

        public async Task<AnimeDto> GetAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
                return null;

            return new AnimeDto
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                Rating = anime.Rating
            };
        }

        public async Task<AnimeDto> AddAnime(AnimeDto animeDto)
        {
            var anime = new Anime
            {
                Title = animeDto.Title,
                Description = animeDto.Description,
                Rating = animeDto.Rating
            };

            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();

            return new AnimeDto
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                Rating = anime.Rating
            };
        }

        public async Task<bool> UpdateAnime(int id, AnimeDto updateDto)
        {
            var dbAnime = await _context.Animes.FindAsync(id);
            if (dbAnime == null)
                return false;

            dbAnime.Title = updateDto.Title;
            dbAnime.Description = updateDto.Description;
            dbAnime.Rating = updateDto.Rating;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnime(int id)
        {
            var dbAnime = await _context.Animes.FindAsync(id);
            if (dbAnime == null)
                return false;

            _context.Animes.Remove(dbAnime);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
