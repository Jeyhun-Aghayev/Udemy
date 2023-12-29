using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.AccountDtos;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.Services.Interfaces
{
    public interface IAccountService
    {
            Task<IdentityResult> Register(RegisterDto registerDto);
            Task<TokenResponseDto> Login(LoginDto loginDto);
        
    }
}
