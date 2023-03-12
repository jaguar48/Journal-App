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

            foreach (var post in blogPostViewModels)
            {
                var author = _authorRepo.GetById(post.AuthorId);
                post.Author = _mapper.Map<AuthorViewModel>(author);
            }

            return blogPostViewModels;
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
            var blogPostEntity = _mapper.Map<BlogPost>(blogPostViewModel);

            var author = _authorRepo.GetById(blogPostEntity.AuthorId );
            if (author == null)
            {
                throw new Exception($"Author with Id {blogPostViewModel.AuthorId} not found.");
            }
            blogPostEntity.AuthorId = author.Id;

            _blogRepo.Add(blogPostEntity);
            _unitOfWork.SaveChanges();
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

            var categories = _catRepo.GetAll;

            var categoryViewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoryViewModels;
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