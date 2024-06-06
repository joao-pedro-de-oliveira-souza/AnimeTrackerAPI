using AnimeTracker.Entities;

namespace AnimeTracker.Repositories
{
    public interface ILightNovelRepository
    {
        Task<List<LightNovel>> GetAllLightNovels();
        Task<LightNovel> GetLightNovel(int id);
        Task<LightNovel> AddLightNovel(LightNovel lightNovel);
        Task<bool> UpdateLightNovel(LightNovel lightNovel);
        Task<bool> DeleteLightNovel(int id);
    }
}
