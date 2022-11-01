using Forum.Models;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("register")]
       public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
       {
            await _service.RegisterUser(dto);
            return Ok();
       }
    }
}
