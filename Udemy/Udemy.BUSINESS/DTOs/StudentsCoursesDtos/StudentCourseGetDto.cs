using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.Entities.Base;

namespace Udemy.BUSINESS.DTOs.StudentsCoursesDtos
{
    public class StudentCourseGetDto:BaseAuditableEntityDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
