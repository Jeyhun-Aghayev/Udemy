using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;

namespace Udemy.CORE.Entities
{
    public class Course : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set;}
        public List<StudentsCourses> StudentsCourses { get; set; }

    }
}
