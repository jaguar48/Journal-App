using BLOG.DAL.Repository;
using System;
using System.Threading.Tasks;

namespace BLOG.DAL.Repository;

public interface IUnitOfWork
{
    IBlogRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    int SaveChanges();
    void Dispose();
    Task<int> SaveChangesAsync();
}

