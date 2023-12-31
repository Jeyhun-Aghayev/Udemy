﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;

namespace Udemy.CORE.Entities
{
    public class StudentsCourses:BaseAuditableEntity
    {
        public int StudentId { get; set;}
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set;}
    }
}
