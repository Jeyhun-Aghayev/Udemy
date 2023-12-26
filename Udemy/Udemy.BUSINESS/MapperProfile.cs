using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.DTOs.CategoryDtos;
using Udemy.CORE.Entities;

namespace Udemy.BUSINESS
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<IQueryable<Category>, IQueryable<CategoryGetDto>>();
            CreateMap<IQueryable<CategoryGetDto>, IQueryable<Category>>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryGetDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
