/*using Blog.DAL.Database;
using BLOG.BLL.Interfaces;

using BLOG.DAL.Entity;


namespace BLOG.BLL.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BlogDbContext _context;

        public AuthorRepository(BlogDbContext context)
        {
            _context = context;
        }

   
        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
        }
        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }
        public void DeleteAuthor(int id)
        {
            var author = GetAuthorById(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
           
        }
    }
}
*/