using AnimeTracker.Dtos;

namespace AnimeTracker.Services
{
    public interface IMangaService
    {
        Task<List<MangaDto>> GetAllMangas();
        Task<MangaDto> GetManga(int id);
        Task<MangaDto> AddManga(MangaDto mangaDto);
        Task<bool> UpdateManga(int id, MangaDto updateDto);
        Task<bool> DeleteManga(int id);
    }
}
