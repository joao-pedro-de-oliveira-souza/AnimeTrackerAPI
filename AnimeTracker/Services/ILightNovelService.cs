using AnimeTracker.Dtos;

namespace AnimeTracker.Services
{
    public interface ILightNovelService
    {
        Task<List<LightNovelDto>> GetAllLightNovels();
        Task<LightNovelDto> GetLightNovel(int id);
        Task<LightNovelDto> AddLightNovel(LightNovelDto lightNovelDto);
        Task<bool> UpdateLightNovel(int id, LightNovelDto updateDto);
        Task<bool> DeleteLightNovel(int id);
    }
}
