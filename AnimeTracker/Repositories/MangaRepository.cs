using AnimeTracker.Data;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly DataContext _context;

        public MangaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Manga>> GetAllMangas()
        {
            return await _context.Mangas.ToListAsync();
        }

        public async Task<Manga> GetManga(int id)
        {
            return await _context.Mangas.FindAsync(id);
        }

        public async Task<Manga> AddManga(Manga manga)
        {
            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();
            return manga;
        }

        public async Task<bool> UpdateManga(Manga manga)
        {
            _context.Mangas.Update(manga);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManga(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null)
                return false;

            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
