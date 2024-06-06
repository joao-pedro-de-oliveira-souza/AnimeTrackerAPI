using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using AnimeTracker.Repositories;

namespace AnimeTracker.Services
{
    public class LightNovelService : ILightNovelService
    {
        private readonly ILightNovelRepository _lightNovelRepository;

        public LightNovelService(ILightNovelRepository lightNovelRepository)
        {
            _lightNovelRepository = lightNovelRepository;
        }

        public async Task<List<LightNovelDto>> GetAllLightNovels()
        {
            var lightNovels = await _lightNovelRepository.GetAllLightNovels();
            return lightNovels.Select(lightNovel => new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            }).ToList();
        }

        public async Task<LightNovelDto> GetLightNovel(int id)
        {
            var lightNovel = await _lightNovelRepository.GetLightNovel(id);
            if (lightNovel == null)
                return null;

            return new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            };
        }

        public async Task<LightNovelDto> AddLightNovel(LightNovelDto lightNovelDto)
        {
            var lightNovel = new LightNovel
            {
                Title = lightNovelDto.Title,
                Description = lightNovelDto.Description,
                Rating = lightNovelDto.Rating
            };

            lightNovel = await _lightNovelRepository.AddLightNovel(lightNovel);

            return new LightNovelDto
            {
                Id = lightNovel.Id,
                Title = lightNovel.Title,
                Description = lightNovel.Description,
                Rating = lightNovel.Rating
            };
        }

        public async Task<bool> UpdateLightNovel(int id, LightNovelDto updateDto)
        {
            var dbLightNovel = await _lightNovelRepository.GetLightNovel(id);
            if (dbLightNovel == null)
                return false;

            dbLightNovel.Title = updateDto.Title;
            dbLightNovel.Description = updateDto.Description;
            dbLightNovel.Rating = updateDto.Rating;

            return await _lightNovelRepository.UpdateLightNovel(dbLightNovel);
        }

        public async Task<bool> DeleteLightNovel(int id)
        {
            return await _lightNovelRepository.DeleteLightNovel(id);
        }
    }
}
