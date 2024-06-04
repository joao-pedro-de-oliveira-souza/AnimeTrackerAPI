using AnimeTracker.Data;
using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Services
{
    public class LightNovelService : ILightNovelService
    {
        private readonly DataContext _context;

        public LightNovelService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<LightNovelDto>> GetAllLightNovels()
        {
            var lightNovels = await _context.LightNovels.ToListAsync();
            return lightNovels.Select(lightNovel => new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            }).ToList();
        }

        public async Task<LightNovelDto> GetLightNovel(int id)
        {
            var lightNovel = await _context.LightNovels.FindAsync(id);
            if (lightNovel == null)
                return null;

            return new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            };
        }

        public async Task<LightNovelDto> AddLightNovel(LightNovelDto lightNovelDto)
        {
            var lightNovel = new LightNovel
            {
                Title = lightNovelDto.Title,
                Description = lightNovelDto.Description,
                Rating = lightNovelDto.Rating
            };

            _context.LightNovels.Add(lightNovel);
            await _context.SaveChangesAsync();

            return new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            };
        }

        public async Task<bool> UpdateLightNovel(int id, LightNovelDto updateDto)
        {
            var dbLightNovel = await _context.LightNovels.FindAsync(id);
            if (dbLightNovel == null)
                return false;

            dbLightNovel.Title = updateDto.Title;
            dbLightNovel.Description = updateDto.Description;
            dbLightNovel.Rating = updateDto.Rating;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLightNovel(int id)
        {
            var dbLightNovel = await _context.LightNovels.FindAsync(id);
            if (dbLightNovel == null)
                return false;

            _context.LightNovels.Remove(dbLightNovel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
