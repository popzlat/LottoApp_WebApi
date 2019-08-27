using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/values
        [Route("register")]
        [HttpPost]
        public void Post([FromBody] UserModel model)
        {
            _userService.Register(model);
        }

        [Route("getAll")]
        [HttpGet]
        public IEnumerable<UserModel> GetAll()
        {
            return _userService.GetAll();
        }

        [Route("authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            return Ok(_userService.Authenticate(model));
        }
    }
}
