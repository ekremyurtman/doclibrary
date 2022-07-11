using DocLibrary.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Dal.Interface
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        DbContext GetContext();
        Dictionary<string, dynamic> GetRepositories();
    }

    public interface IUnitOfWork<T> : IUnitOfWork where T : DbContext, IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
