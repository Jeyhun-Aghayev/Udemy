using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.Entities.Base;

namespace Udemy.BUSINESS.DTOs.CategoryDtos
{ 
    public class CategoryUpdateDto :BaseEntityDto
    {
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Kateqoriya adı mutleqdir.")
                .MinimumLength(3).WithMessage("Kateqoriya adı en az 3 herf olmalıdır.")
                .MaximumLength(100).WithMessage("Kateqoriya adı en cox 55 herf olmalıdır.");
        }
    }
}
