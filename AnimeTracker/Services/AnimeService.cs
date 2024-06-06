using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using AnimeTracker.Repositories;

namespace AnimeTracker.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(
            IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<List<AnimeDto>> GetAllAnimes()
        {
            var animes = await _animeRepository.GetAllAnimes();
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
            var anime = await _animeRepository.GetAnime(id);
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

            anime = await _animeRepository.AddAnime(anime);

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
            var dbAnime = await _animeRepository.GetAnime(id);
            if (dbAnime == null)
                return false;

            dbAnime.Title = updateDto.Title;
            dbAnime.Description = updateDto.Description;
            dbAnime.Rating = updateDto.Rating;

            return await _animeRepository.UpdateAnime(dbAnime);
        }

        public async Task<bool> DeleteAnime(int id)
        {
            return await _animeRepository.DeleteAnime(id);
        }
    }
}
