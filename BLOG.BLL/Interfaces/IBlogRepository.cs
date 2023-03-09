using BLOG.DAL.Entity;

namespace BLOG.BLL.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPostById(int id);
        void AddBlogPost(BlogPost post);
        void UpdateBlogPost(BlogPost post);
        void DeleteBlogPost(int id);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Tag> GetAllTags();
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<BlogPost> GetBlogPostsByTag(int tagId);
    }

}
