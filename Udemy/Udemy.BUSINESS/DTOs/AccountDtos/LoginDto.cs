using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.BUSINESS.DTOs.AccountDtos
{
    public record LoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty()
                .WithMessage("Username or email cannot be empty.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty");
        }
    }
}
