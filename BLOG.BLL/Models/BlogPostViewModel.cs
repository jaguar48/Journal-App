using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Models
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime PostedOn { get; set; }
        public AuthorViewModel? Author { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
        public List<TagViewModel>? Tags { get; set; }
    }
}
