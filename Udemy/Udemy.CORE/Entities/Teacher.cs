using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;

namespace Udemy.CORE.Entities
{
    public class Teacher : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
    }
}
