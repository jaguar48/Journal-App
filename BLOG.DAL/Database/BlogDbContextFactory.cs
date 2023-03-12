/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Blog.DAL.Database
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContextFactory()
        {
        }

        public BlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();

            string connectionString = @"Data Source=.;Initial Catalog=BlogDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });

            // Test the connection and print the connection status
            using (var dbContext = new BlogDbContext(optionsBuilder.Options))
            {
                try
                {
                    dbContext.Database.OpenConnection();
                    Console.WriteLine("Database connection successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed. Error: {ex.Message}");
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}*/