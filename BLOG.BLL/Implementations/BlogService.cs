using BLOG.BLL.Interfaces;
using System.Collections.Generic;
using BLOG.BLL.Models;
using BLOG.DAL.Entity;
using AutoMapper;

namespace BLOG.BLL.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public List<BlogPostViewModel> GetAllBlogPosts()
        {
            var blogPosts = _blogRepository.GetAllBlogPosts();
            var blogPostViewModels = _mapper.Map<List<BlogPostViewModel>>(blogPosts);
            return blogPostViewModels;
        }

        public BlogPostViewModel GetBlogPostById(int id)
        {
            var blogPost = _blogRepository.GetBlogPostById(id);
            var blogPostViewModel = _mapper.Map<BlogPostViewModel>(blogPost);
            return blogPostViewModel;
        }

        public void AddBlogPost(BlogPostViewModel blogPostViewModel)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostViewModel);
            _blogRepository.AddBlogPost(blogPost);
        }

        public void UpdateBlogPost(BlogPostViewModel blogPostViewModel)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostViewModel);
            _blogRepository.UpdateBlogPost(blogPost);
        }

        public void DeleteBlogPost(int id)
        {
            _blogRepository.DeleteBlogPost(id);
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _blogRepository.GetAllCategories();
            var categoryViewModels = _mapper.Map<List<CategoryViewModel>>(categories);
            return categoryViewModels;
        }

        public List<TagViewModel> GetAllTags()
        {
            var tags = _blogRepository.GetAllTags();
            var tagViewModels = _mapper.Map<List<TagViewModel>>(tags);
            return tagViewModels;
        }

        public List<AuthorViewModel> GetAllAuthors()
        {
            var authors = _blogRepository.GetAllAuthors();
            var authorViewModels = _mapper.Map<List<AuthorViewModel>>(authors);
            return authorViewModels;
        }
    }
}