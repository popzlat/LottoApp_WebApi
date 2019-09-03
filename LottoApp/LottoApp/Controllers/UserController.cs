using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
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
            
            _logger.LogInformation($"The user: {model.Username} logged in.");
            return Ok(_userService.Authenticate(model));
        }
    }
}
