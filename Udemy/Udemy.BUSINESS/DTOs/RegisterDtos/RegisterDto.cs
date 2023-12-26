using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Udemy.BUSINESS.DTOs.RegisterDtos
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(25)
                .WithMessage("Name cannot be longer than 25 characters");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(45)
                .WithMessage("Surname cannot be longer than 45 characters");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(60)
                .WithMessage("Username cannot be longer than 60 characters");
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Password)
                .Must(x =>
                {
                    Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
                    Match match = regex.Match(x);
                    return match.Success;
                })
                .WithMessage("Password entered in incorrect format.");
            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Confirmpaswordla Pasword eyni olmalidir");

        }

    }
}
