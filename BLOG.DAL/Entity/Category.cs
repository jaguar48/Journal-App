using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
