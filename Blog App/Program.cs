using Blog.DAL.Database;
using BLOG.BLL.Implementations;
using BLOG.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using BLOG.BLL.Models;
using BLOG.DAL.Repository;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<BlogDbContext>>(); 
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddAutoMapper(Assembly.Load("BLOG.BLL"));

builder.Services.AddAutoMapper (typeof(BlogProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
