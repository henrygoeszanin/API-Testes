using APITestes.Models;
using APITestes.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITestes.Controllers.Users
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel userModel)
        {
            var createdUser = await _userService.CreateUser(userModel);

            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.UserId }, createdUser);
        }
    }
}
