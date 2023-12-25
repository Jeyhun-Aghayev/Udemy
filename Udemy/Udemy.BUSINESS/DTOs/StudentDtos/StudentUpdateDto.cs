﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.BUSINESS.Entities.Base;

namespace Udemy.BUSINESS.DTOs.StudentDtos
{
    public class StudentUpdateDto:BaseEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
