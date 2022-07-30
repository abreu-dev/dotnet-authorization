using Autho.Application.Contracts.User;
using Autho.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("api/users")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpPost, Route("api/users")]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            await _userService.AddUser(creationDto);
            return Ok();
        }
    }
}
