using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.CategoryDtos;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<CategoryGetDto>> GetAllAsync();
        Task<ICollection<Category>> RecycleBin();
        Task<CategoryGetDto> GetById(int id);
        Task Create(CategoryCreateDto createCategoryDto);
        Task Delete(int id);
        Task DeleteAll();
        Task Update(CategoryUpdateDto updateCategoryDto);
        Task Restore();
    }
}
