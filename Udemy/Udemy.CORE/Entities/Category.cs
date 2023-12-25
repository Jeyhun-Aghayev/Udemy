using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CORE.Entities.Base;

namespace Udemy.CORE.Entities
{
    public class Category:BaseAuditableEntity
    {
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category>? Children { get; set; }
    }
}
