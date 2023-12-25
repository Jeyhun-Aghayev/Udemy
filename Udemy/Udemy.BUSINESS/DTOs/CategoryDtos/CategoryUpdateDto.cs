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
}
