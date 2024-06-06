using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using AnimeTracker.Repositories;

namespace AnimeTracker.Services
{
    public class MangaService : IMangaService
    {
        private readonly IMangaRepository _mangaRepository;

        public MangaService(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public async Task<List<MangaDto>> GetAllMangas()
        {
            var mangas = await _mangaRepository.GetAllMangas();
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
            var manga = await _mangaRepository.GetManga(id);
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

            manga = await _mangaRepository.AddManga(manga);

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
            var dbManga = await _mangaRepository.GetManga(id);
            if (dbManga == null)
                return false;

            dbManga.Title = updateDto.Title;
            dbManga.Description = updateDto.Description;
            dbManga.Rating = updateDto.Rating;

            return await _mangaRepository.UpdateManga(dbManga);
        }

        public async Task<bool> DeleteManga(int id)
        {
            return await _mangaRepository.DeleteManga(id);
        }
    }
}
