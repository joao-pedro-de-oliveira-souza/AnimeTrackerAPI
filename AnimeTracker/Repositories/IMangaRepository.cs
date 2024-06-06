using AnimeTracker.Entities;

namespace AnimeTracker.Repositories
{
    public interface IMangaRepository
    {
        Task<List<Manga>> GetAllMangas();
        Task<Manga> GetManga(int id);
        Task<Manga> AddManga(Manga manga);
        Task<bool> UpdateManga(Manga manga);
        Task<bool> DeleteManga(int id);
    }
}
