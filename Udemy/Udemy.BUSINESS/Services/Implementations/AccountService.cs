using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.AccountDtos;
using Udemy.BUSINESS.Exceptions.User;
using Udemy.BUSINESS.ExternalServices.İnterfaces;
using Udemy.BUSINESS.Services.Interfaces;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail) ?? await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);
            if (user == null) throw new UserNotFoundException();
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) throw new UserNotFoundException();

            return _tokenService.CreateToken(user);
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            AppUser user = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            return result;
        }
    }
}
