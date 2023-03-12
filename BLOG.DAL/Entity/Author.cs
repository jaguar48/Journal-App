using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entity
{
    public class Author : BaseEntity
    {
        public string ? Name { get; set; } = string.Empty;
        public string ? Email { get; set; } = string.Empty;
        public IEnumerable<BlogPost> Tasks { get; set; } = new List<BlogPost>();
    }

}
