using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.BUSINESS.DTOs.RegisterDtos;
using Udemy.BUSINESS.Services.Interfaces;

namespace Udemy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterService _userService;

        public AccountsController(IRegisterService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto appUserDto)
        {
            var result = await _userService.RegisterUserAsync(appUserDto);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            return BadRequest(result.Errors);
        }

    }
}
