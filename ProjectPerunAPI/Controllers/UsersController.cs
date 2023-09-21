using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;
using System.Data;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetUsers()
        {
            return JsonConvert.SerializeObject( await _usersService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneUser(int id)
        {
            return JsonConvert.SerializeObject( await _usersService.GetOneUser(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateUser([FromBody] UserModel userData)
        {
            return JsonConvert.SerializeObject(await _usersService.UpdateUser(userData));
        }

        [HttpPost]
        public async Task<string> InsertUser([FromBody] UserWrapperModel userData)
        {
            if(userData == null || userData.UserData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject( await _usersService.InsertUser(userData.UserData));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            return JsonConvert.SerializeObject( await _usersService.DeleteUser(id));
        }

        [HttpPut("login")]
        public async Task<string> LoginUser(LoginModel loginData)
        {
            if (loginData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject( await _usersService.LoginUser(loginData));
        }
    }
}
