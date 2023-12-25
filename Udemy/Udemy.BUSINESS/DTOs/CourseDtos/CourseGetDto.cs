using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.Entities.Base;

namespace Udemy.BUSINESS.DTOs.CourseDtos
{
    public class CourseGetDto:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
    }
}
