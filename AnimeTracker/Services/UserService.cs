using AnimeTracker.Dtos;
using AnimeTracker.Entities;
using AnimeTracker.Repositories;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;

namespace AnimeTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            if(userDto.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
                byte[] passwordSalt = hmac.Key;

                user.ChangePassword(passwordHash, passwordSalt);
            }

            var updatedUser = await _userRepository.AddUser(user);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var updatedUser = await _userRepository.UpdateUser(user);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}