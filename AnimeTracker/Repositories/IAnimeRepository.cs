using AnimeTracker.Entities;

namespace AnimeTracker.Repositories
{
    public interface IAnimeRepository
    {
        Task<List<Anime>> GetAllAnimes();
        Task<Anime> GetAnime(int id);
        Task<Anime> AddAnime(Anime anime);
        Task<bool> UpdateAnime(Anime anime);
        Task<bool> DeleteAnime(int id);
    }
}
