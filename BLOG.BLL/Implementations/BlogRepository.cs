using Blog.DAL.Database;
using BLOG.BLL.Interfaces;
using BLOG.DAL.Entity;

namespace BLOG.BLL.Implementations
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return _context.BlogPosts.ToList();
        }

        public BlogPost GetBlogPostById(int id)
        {
            return _context.BlogPosts.FirstOrDefault(p => p.Id == id);
        }

        public void AddBlogPost(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
        }

        public void UpdateBlogPost(BlogPost post)
        {
            _context.BlogPosts.Update(post);
            _context.SaveChanges();
        }

        public void DeleteBlogPost(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public IEnumerable<BlogPost> GetBlogPostsByTag(int tagId)
        {
            return _context.BlogPosts.Where(p => p.Tags.Any(t => t.Id == tagId)).ToList();
        }
    }
}
