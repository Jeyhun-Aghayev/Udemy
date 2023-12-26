using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.RegisterDtos;
using Udemy.BUSINESS.Services.Interfaces;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public RegisterService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto appUserDto)
        {
            var user = new AppUser { UserName = appUserDto.Username, Email = appUserDto.Email, Name = appUserDto.Name, Surname = appUserDto.Surname };
            var result = await _userManager.CreateAsync(user, appUserDto.Password);

            return result;
        }
    }
}
