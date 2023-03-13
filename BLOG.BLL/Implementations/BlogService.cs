using AutoMapper;
using BLOG.BLL.Interfaces;
using BLOG.BLL.Models;
using BLOG.DAL.Entity;
using BLOG.DAL.Repository;

namespace BLOG.BLL.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IBlogRepository<BlogPost> _blogRepo;
        private readonly IBlogRepository<Author> _authorRepo;
        private readonly IBlogRepository<Category> _catRepo;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authorRepo = unitOfWork.GetRepository<Author>();
            _catRepo = unitOfWork.GetRepository<Category>();
            _blogRepo = unitOfWork.GetRepository<BlogPost>();

        }


        public IEnumerable<BlogPostViewModel> GetAllBlogPosts()
        {
            var blogPosts = _blogRepo.GetAll();
            var blogPostViewModels = _mapper.Map<IEnumerable<BlogPostViewModel>>(blogPosts);

            var authorIds = blogPostViewModels.Select(p => p.AuthorId).Distinct().ToList();
            var authors = _authorRepo.GetAll().Where(a => authorIds.Contains(a.Id))
                                              .Select(a => _mapper.Map<AuthorViewModel>(a))
                                              .ToList();

            var categoryIds = blogPostViewModels.SelectMany(p => p.Categories.Select(c => c.Id)).Distinct().ToList();
            var categories = _catRepo.GetAll().Where(c => categoryIds.Contains(c.Id))
                                                   .Select(c => _mapper.Map<CategoryViewModel>(c))
                                                   .ToList();

            var blogPostViewModelsWithAuthorsAndCategories = blogPostViewModels.Join(authors,
                post => post.AuthorId,
                author => author.Id,
                (post, author) =>
                {
                    post.Author = author;
                    return post;
                }).ToList();

            foreach (var post in blogPostViewModelsWithAuthorsAndCategories)
            {
                var postCategories = categories.Where(c => post.Categories.Any(pc => pc.Id == c.Id)).ToList();
                post.Categories = postCategories;
            }

            return blogPostViewModelsWithAuthorsAndCategories;
        }




        public BlogPostViewModel GetBlogPostById(int id)
        {
            var blogPost = _blogRepo.GetById(id);
            var author = _authorRepo.GetById(blogPost.AuthorId);

            var blogPostViewModel = _mapper.Map<BlogPostViewModel>(blogPost);
            blogPostViewModel.Author = _mapper.Map<AuthorViewModel>(author);

            return blogPostViewModel;
        }




        public void AddBlogPost(BlogPostViewModel blogPostViewModel)
        {
            try
            {
                var blogPostEntity = _mapper.Map<BlogPost>(blogPostViewModel);

                var author = _authorRepo.GetById(blogPostEntity.Author.Id);
                if (author == null)
                {
                    throw new Exception($"Author with Id {blogPostViewModel.AuthorId} not found.");
                }

                blogPostEntity.Author = author;

                _blogRepo.Add(blogPostEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
              
                Console.WriteLine(ex.Message);

              
                throw;
            }
        }


        public void UpdateBlogPost(BlogPostViewModel blogPostViewModel)
        {
            var blogPostEntity = _mapper.Map<BlogPost>(blogPostViewModel);
            blogPostEntity.LastUpdatedDate = DateTime.Now;
            _blogRepo.Update(blogPostEntity);
            _unitOfWork.SaveChanges();
        }

      


        public void DeleteBlogPost(int id)
        {
            _blogRepo.DeleteById(id);
            _unitOfWork.SaveChanges();
        }

        public void AddCategory(CategoryViewModel categoryViewModel)
        {
            var blogCategoryEntity = _mapper.Map<Category>(categoryViewModel);

            _catRepo.Add(blogCategoryEntity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var categories = _catRepo.GetAll();
            try
            {
                var categoryViewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

                foreach (var categoryViewModel in categoryViewModels)
                {
                    var blogPostViewModels = _mapper.Map<IEnumerable<BlogPostViewModel>>(categoryViewModel.BlogPosts);

                    categoryViewModel.BlogPosts = blogPostViewModels;
                }

                return categoryViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }




        public void AddAuthor(AuthorViewModel authorViewModel)
        {
            var blogAuthorEntity = _mapper.Map<Author>(authorViewModel);

            try
            {
                _authorRepo.Add(blogAuthorEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

       
        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            var authors = _authorRepo.GetAll();
            var authorViewModels = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
            return authorViewModels;
        }



       

       
    }
}