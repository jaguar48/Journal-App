using AutoMapper;
using BLOG.DAL.Entity  ;
using BLOG.BLL.Models;

namespace BLOG.BLL.Models
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogPost, BlogPostViewModel>();
            CreateMap<BlogPostViewModel, BlogPost>();
        }
    }
}
