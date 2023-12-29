using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.BUSINESS.DTOs.AccountDtos;
using Udemy.BUSINESS.Services.Interfaces;

namespace Udemy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService ccountService)
        {
            _accountService = ccountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto appUserDto)
        {
            var result = await _accountService.Register(appUserDto);

            if (result.Succeeded)
            {
                return Ok("Registration successfull");
            }

            return BadRequest(result.Errors);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto);
            return Ok(result);
        }
    }
}
