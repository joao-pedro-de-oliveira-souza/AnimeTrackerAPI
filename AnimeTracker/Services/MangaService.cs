using AnimeTracker.Data;
using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Services
{
    public class MangaService : IMangaService
    {
        private readonly DataContext _context;

        public MangaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MangaDto>> GetAllMangas()
        {
            var mangas = await _context.Mangas.ToListAsync();
            return mangas.Select(manga => new MangaDto
            {
                Id = manga.Id,
                Title = manga.Title,
                Description = manga.Description,
                Rating = manga.Rating
            }).ToList();
        }

        public async Task<MangaDto> GetManga(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null)
                return null;

            return new MangaDto
            {
                Id = manga.Id,
                Title = manga.Title,
                Description = manga.Description,
                Rating = manga.Rating
            };
        }

        public async Task<MangaDto> AddManga(MangaDto mangaDto)
        {
            var manga = new Manga
            {
                Title = mangaDto.Title,
                Description = mangaDto.Description,
                Rating = mangaDto.Rating
            };

            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();

            return new MangaDto
            {
                Id = manga.Id,
                Title = manga.Title,
                Description = manga.Description,
                Rating = manga.Rating
            };
        }

        public async Task<bool> UpdateManga(int id, MangaDto updateDto)
        {
            var dbManga = await _context.Mangas.FindAsync(id);
            if (dbManga == null)
                return false;

            dbManga.Title = updateDto.Title;
            dbManga.Description = updateDto.Description;
            dbManga.Rating = updateDto.Rating;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManga(int id)
        {
            var dbManga = await _context.Mangas.FindAsync(id);
            if (dbManga == null)
                return false;

            _context.Mangas.Remove(dbManga);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
