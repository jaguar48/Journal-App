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
            IEnumerable<BlogPostViewModel> myblog = _blogService.GetAllBlogPosts();
            return View(myblog);
        }

        public IActionResult Create()
        {

            var categories = _blogService.GetAllCategories();
            var authors = _blogService.GetAllAuthors();
            ViewData["Categories"] = categories;
            ViewData["Authors"] = authors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPostViewModel blogPostViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    

                    _blogService.AddBlogPost(blogPostViewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error adding blog post: {ex.Message}");
                }
            }

            var categories = _blogService.GetAllCategories();
            var authors = _blogService.GetAllAuthors();
            ViewData["Categories"] = categories;
            ViewData["Authors"] = authors;
            return View(blogPostViewModel);
        }


        public IActionResult Details(int id)
        {
            var blogPostViewModel = _blogService.GetBlogPostById(id);

            if (blogPostViewModel == null)
            {
                return NotFound();
            }

            return View(blogPostViewModel);
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
                /*var categories = _blogService.GetAllCategories();*/
                /* var tags = _blogService.GetAllTags();*/
                var authors = _blogService.GetAllAuthors();
                /*ViewData["Categories"] = categories;*/
                /*ViewData["Tags"] = tags;*/
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
               /* var categories = _blogService.GetAllCategories();*/
                var authors = _blogService.GetAllAuthors();
               /* ViewData["Categories"] = categories;*/
                ViewData["Authors"] = authors;
                return View(blogPostViewModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var blogPostViewModel = _blogService.GetBlogPostById(id);
            return View(blogPostViewModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _blogService.DeleteBlogPost(id);
            return RedirectToAction(nameof(Index));
        }




        public IActionResult CreateCategory()
        {
            return View();
        }

        // POST: Blog/CreateCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddCategory(categoryViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(categoryViewModel);
            }
        }


    

        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAuthor(AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddAuthor(authorViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(authorViewModel);
            }
        }
    }
}