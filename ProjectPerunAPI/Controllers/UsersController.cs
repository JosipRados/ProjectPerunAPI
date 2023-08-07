using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetUsers()
        {
            return await _usersService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneUser(int id)
        {
            return await _usersService.GetOneUser(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateUser([FromBody] UserModel userData)
        {
            return await _usersService.UpdateUser(userData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertUser([FromBody] UserModel userData)
        {
            return await _usersService.InsertUser(userData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteUser(int id)
        {
            return await _usersService.DeleteUser(id);
        }
    }
}
