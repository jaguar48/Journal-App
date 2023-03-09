using BLOG.BLL.Interfaces;
using BLOG.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BLOG.WEB.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            List<BlogPostViewModel> blogPosts = _blogService.GetAllBlogPosts();
            return View(blogPosts);
        }

        public IActionResult Create()
        {
            var categories = _blogService.GetAllCategories();
            var tags = _blogService.GetAllTags();
            var authors = _blogService.GetAllAuthors();
            ViewData["Categories"] = categories;
            ViewData["Tags"] = tags;
            ViewData["Authors"] = authors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPostViewModel blogPostViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddBlogPost(blogPostViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var categories = _blogService.GetAllCategories();
                var tags = _blogService.GetAllTags();
                var authors = _blogService.GetAllAuthors();
                ViewData["Categories"] = categories;
                ViewData["Tags"] = tags;
                ViewData["Authors"] = authors;
                return View(blogPostViewModel);
            }
        }

        public IActionResult Edit(int id)
        {
            var blogPostViewModel = _blogService.GetBlogPostById(id);
            if (blogPostViewModel == null)
            {
                return NotFound();
            }
            else
            {
                var categories = _blogService.GetAllCategories();
                var tags = _blogService.GetAllTags();
                var authors = _blogService.GetAllAuthors();
                ViewData["Categories"] = categories;
                ViewData["Tags"] = tags;
                ViewData["Authors"] = authors;
                return View(blogPostViewModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(BlogPostViewModel blogPostViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdateBlogPost(blogPostViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var categories = _blogService.GetAllCategories();
                var tags = _blogService.GetAllTags();
                var authors = _blogService.GetAllAuthors();
                ViewData["Categories"] = categories;
                ViewData["Tags"] = tags;
                ViewData["Authors"] = authors;
                return View(blogPostViewModel);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _blogService.DeleteBlogPost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
