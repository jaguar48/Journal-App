/*using Blog.DAL.Database;
u

namespace BLOG.DAL.Seeds
{
    public class SeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            BlogDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<BlogDbContext>();

            if (context.BlogPosts.Any())
            {
                context.BlogPosts.AddRange(UsersWithToDos());
                context.SaveChangesAsync();
            }

        }
        private static IEnumerable<BlogPost> SeedData()
        {
            // Create some sample data
            var author1 = new AuthorViewModel { Name = "John Doe" };
            var author2 = new AuthorViewModel { Name = "Jane Smith" };

            var category1 = new CategoryViewModel { Name = "Technology" };
            var category2 = new CategoryViewModel { Name = "Business" };
            var category3 = new CategoryViewModel { Name = "Health" };

            var tag1 = new TagViewModel { Name = "ASP.NET Core" };
            var tag2 = new TagViewModel { Name = "Angular" };
            var tag3 = new TagViewModel { Name = "React" };

            var post1 = new BlogPostViewModel
            {
                Title = "Getting started with ASP.NET Core",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                PostedOn = DateTime.Now,
                Author = author1,
                Categories = new List<CategoryViewModel> { category1, category2 },
                Tags = new List<TagViewModel> { tag1 }
            };

            var post2 = new BlogPostViewModel
            {
                Title = "Building web apps with Angular",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                PostedOn = DateTime.Now,
                Author = author2,
                Categories = new List<CategoryViewModel> { category1, category3 },
                Tags = new List<TagViewModel> { tag2, tag3 }
            };

            // Add the data to the database
            _blogService.AddAuthor(author1);
            _blogService.AddAuthor(author2);

            _blogService.AddCategory(category1);
            _blogService.AddCategory(category2);
            _blogService.AddCategory(category3);

            _blogService.AddTag(tag1);
            _blogService.AddTag(tag2);
            _blogService.AddTag(tag3);

            _blogService.AddBlogPost(post1);
            _blogService.AddBlogPost(post2);
        }
    }

}
}
*/