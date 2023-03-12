using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOG.BLL.Models;

namespace BLOG.BLL.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<BlogPostViewModel> GetAllBlogPosts();
        BlogPostViewModel GetBlogPostById(int id);
        void AddBlogPost(BlogPostViewModel blogPostViewModel);
        void UpdateBlogPost(BlogPostViewModel blogPostViewModel);
        void DeleteBlogPost(int id);
        IEnumerable<CategoryViewModel> GetAllCategories();
       /* IEnumerable<TagViewModel> GetAllTags();*/
        IEnumerable<AuthorViewModel> GetAllAuthors();
        public void AddAuthor(AuthorViewModel authorViewModel);
        void AddCategory(CategoryViewModel categoryViewModel);
       /* void AddTag(TagViewModel categoryViewModel);*/

    }

}
