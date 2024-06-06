using AnimeTracker.Data;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Repositories
{
    public class LightNovelRepository : ILightNovelRepository
    {
        private readonly DataContext _context;

        public LightNovelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<LightNovel>> GetAllLightNovels()
        {
            return await _context.LightNovels.ToListAsync();
        }

        public async Task<LightNovel> GetLightNovel(int id)
        {
            return await _context.LightNovels.FindAsync(id);
        }

        public async Task<LightNovel> AddLightNovel(LightNovel lightNovel)
        {
            _context.LightNovels.Add(lightNovel);
            await _context.SaveChangesAsync();
            return lightNovel;
        }

        public async Task<bool> UpdateLightNovel(LightNovel lightNovel)
        {
            _context.LightNovels.Update(lightNovel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLightNovel(int id)
        {
            var lightNovel = await _context.LightNovels.FindAsync(id);
            if (lightNovel == null)
                return false;

            _context.LightNovels.Remove(lightNovel);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
