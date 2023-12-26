using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.CategoryDtos;
using Udemy.BUSINESS.Services.Interfaces;
using Udemy.CORE.Entities;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.BUSINESS.Services.Implementations
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

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
            _repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
             _repo.Delete(id);
             _repo.SaveChangesAsync();
        }

        public async Task<IQueryable<CategoryGetDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            IQueryable<CategoryGetDto> get = _mapper.Map<IQueryable<CategoryGetDto>>(categories);
            return get;
        }

        public async Task<CategoryGetDto> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            return _mapper.Map<CategoryGetDto>(await _repo.GetById(id));
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
            _repo.SaveChangesAsync();
        }
        public async Task Restore()
        {
            _repo.Restore();
            _repo.SaveChangesAsync();
        }
        public async Task DeleteAll()
        {
            _repo.DeleteAll();
            _repo.SaveChangesAsync();
        }
    }
}
