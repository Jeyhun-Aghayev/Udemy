using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.BUSINESS.DTOs.CategoryDtos
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Category adı mutleqdir.")
                .MinimumLength(3).WithMessage("Category adı en az 3 herf olmalıdır.")
                .MaximumLength(100).WithMessage("Category adı en cox 55 herf olmalıdır.");
        }
    }
}
