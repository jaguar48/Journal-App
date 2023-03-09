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
        List<BlogPostViewModel> GetAllBlogPosts();
        BlogPostViewModel GetBlogPostById(int id);
        void AddBlogPost(BlogPostViewModel blogPostViewModel);
        void UpdateBlogPost(BlogPostViewModel blogPostViewModel);
        void DeleteBlogPost(int id);
        List<CategoryViewModel> GetAllCategories();
        List<TagViewModel> GetAllTags();
        List<AuthorViewModel> GetAllAuthors();
    }

}
