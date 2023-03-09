using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.DAL.Entity
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
