using AnimeTracker.Dtos;
using AnimeTracker.Models;
using AnimeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserService _userService;

        public UserController(IAuthenticateService authenticateService, IUserService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> AddUser(UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("Invalid data");

            var userExists = await _authenticateService.UserExists(userDto.Email);

            if (userExists)
                return BadRequest("Email already used");

            var user = await _userService.AddUser(userDto);

            if (user == null)
                return BadRequest("Error ocurred in sign in");

            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken { Token = token };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel loginModel)
        {
            var userExists = await _authenticateService.UserExists(loginModel.Email);
            if (!userExists)
                return Unauthorized("User doesn't exists.");

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
                return Unauthorized("User or password invalid.");

            var user = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken { Token = token };
        }
    }
}