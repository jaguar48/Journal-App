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
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedDate { get; set; }
        public int AuthorId { get; set; }
        
        public AuthorViewModel? Author { get; set; }
        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }

}



