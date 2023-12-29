using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.AccountDtos;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.ExternalServices.İnterfaces
{
    public interface ITokenService
    {
        TokenResponseDto CreateToken(AppUser user, int expireDate = 60);
    }
}
