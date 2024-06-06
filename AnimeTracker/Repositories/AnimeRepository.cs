using AnimeTracker.Data;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;

        public AnimeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Anime>> GetAllAnimes()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime> GetAnime(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<Anime> AddAnime(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<bool> UpdateAnime(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
                return false;

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
