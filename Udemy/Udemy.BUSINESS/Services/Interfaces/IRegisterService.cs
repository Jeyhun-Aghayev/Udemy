using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.RegisterDtos;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.Services.Interfaces
{
    public interface IRegisterService
    {
        //Task<AppUser> GetAppUSerByUserOrEmail(string UserOrEmail);
        Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto);
        //Task Register(RegisterDto dto);
        //Task<bool> Delete(string UserOrEmail, string password);
    }
}
