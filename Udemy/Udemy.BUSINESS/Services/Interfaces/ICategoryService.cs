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
        Task<ICollection<Category>> GetAllAsync();
        Task<ICollection<Category>> RecycleBin();
        Task<Category> GetById(int id);
        Task Create(CategoryCreateDto createCategoryDto);
        Task Delete(int id);
        Task deleteAll();
        Task Update(CategoryUpdateDto updateCategoryDto);
        Task Restore();
    }
}
