using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.BUSINESS.Entities.Base
{
    public abstract class BaseAuditableEntityDto : BaseEntityDto
    {
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
