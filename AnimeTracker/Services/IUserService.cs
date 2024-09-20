using AnimeTracker.Dtos;

namespace AnimeTracker.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUser(int id);
        Task<UserDto> AddUser(UserDto userDto);
        Task<UserDto> UpdateUser(UserDto userDto);
        Task<UserDto> DeleteUser(int id);
    }
}
