using AnimeTracker.Dtos;

namespace AnimeTracker.Services
{
    public interface IAnimeService
    {
        Task<List<AnimeDto>> GetAllAnimes();
        Task<AnimeDto> GetAnime(int id);
        Task<AnimeDto> AddAnime(AnimeDto animeDto);
        Task<bool> UpdateAnime(int id, AnimeDto updateDto);
        Task<bool> DeleteAnime(int id);
    }
}
