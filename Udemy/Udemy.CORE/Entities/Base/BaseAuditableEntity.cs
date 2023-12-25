using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CORE.Entities.Base
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
