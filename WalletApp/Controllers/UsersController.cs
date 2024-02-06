using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletAppApi.Data;
using WalletAppApi.Models;
using WalletAppApi.Dtos;
using WalletAppApi.Repositories.IRepositories;
using WalletAppApi.Mappers;

namespace WalletAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();

            var userModels = users.Select(u => u.ToUserDto());

            return userModels.ToList();
        }

        /// <summary>
        /// Get User by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        /// <summary>
        /// Update info for existing user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> Update([FromRoute] int id, [FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userModel = new User() { Email = user.Email, UserName = user.UserName, Created = user.Created };
                var userUpdated = await _userRepository.UpdateUser(id, userModel);

                if (userUpdated != null) 
                {
                    return Ok(userUpdated.ToUserDto());
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> Register(UserDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var appUser = new User() { UserName = user.UserName, Email = user.Email, Created = user.Created };

                var userModel = await _userRepository.CreateUser(appUser);

                return Ok(userModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var appUser = await _userRepository.DeleteUser(id);
            if (appUser == null) 
            {
                return NotFound("User not found");
            }

            return Ok(appUser.ToUserDto());
        }
    }
}
