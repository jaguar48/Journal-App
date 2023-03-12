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
        public string DisplayedDate => LastUpdatedDate.HasValue ? LastUpdatedDate.Value.ToString("dd/MM/yyyy HH:mm") : PostedOn.ToString("dd/MM/yyyy HHH:mm");
        public AuthorViewModel? Author { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
    }

}



