using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.CategoryDtos;
using Udemy.CORE.Entities;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.BUSINESS.Services.Implementations
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task Create(CategoryCreateDto createCategoryDto)
        {
            
            Category category = new Category()
            {
                Title = createCategoryDto.Title,
                CreateTime = DateTime.Now,
                ParentId = createCategoryDto.ParentId
            };
            await _repo.Create(category);
            _repo.Save();
        }

        public async Task Delete(int id)
        {
             _repo.Delete(id);
             _repo.Save();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return await categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            return await _repo.GetById(id);
        }

        public async Task<ICollection<Category>> RecycleBin()
        {
            var categories = await _repo.RecycleBin();
            return await categories.ToListAsync();
        }

        public async Task Update(CategoryUpdateDto updateCategoryDto)
        {

            if (updateCategoryDto == null) throw new Exception("Bad Request");

            var existingCategory = await _repo.GetById(updateCategoryDto.Id);
            existingCategory.Title = updateCategoryDto.Title;
            bool exsistparent = false;
            if (await _repo.Check(updateCategoryDto.ParentId) != null)
            {
                 var parent = await _repo.GetById(updateCategoryDto.ParentId);
                if(parent != null) { exsistparent = true; }
            }
            if(exsistparent) existingCategory.ParentId = updateCategoryDto.ParentId;
            else throw new Exception("Bad Request");

            /*if (updateCategoryDto.LogoImg != null)
            {
                existingCategory.LogoUrl.RemoveFile("C:\\Users\\User\\Desktop\\Repos\\Api_Ntire\\App.BUSINESS\\Upload\\");
                existingCategory.LogoUrl = updateCategoryDto.LogoImg.UploadFile(folderName: "C:\\Users\\User\\Desktop\\Repos\\Api_Ntire\\App.BUSINESS\\Upload\\");
            }*/
            _repo.Update(existingCategory);
            _repo.Save();
        }
        public async Task Restore()
        {
            _repo.Restore();
            _repo.Save();
        }

        public async Task deleteAll()
        {
            _repo.DeleteAll();
            _repo.Save();
        }
    }
}
