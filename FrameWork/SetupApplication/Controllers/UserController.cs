using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SetupApplication.models;
using SetupApplication.service;

namespace SetupApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet(Name ="Users")]
        public async Task<ActionResult <List<UserModel>>> GetUsers()
        {
            try
            {
                return Ok(await _userService.GetUserList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult> PostUser([FromBody]UserModel newUser)
        {
            try
            {
               UserModel user = await _userService.CreateUser(newUser);
               return Created ("UserCreated",user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
