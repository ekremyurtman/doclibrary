using DocLibrary.Dal.Interface;
using DocLibrary.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Dal.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _dataContext;
        protected Dictionary<string, dynamic> _repositories;

        public UnitOfWork()
        {
            _repositories = new Dictionary<string, dynamic>();
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public virtual DbContext GetContext()
        {
            return _dataContext;
        }

        public Dictionary<string, dynamic> GetRepositories()
        {
            return _repositories;
        }
    }

    public class UnitOfWork<T> : UnitOfWork, IUnitOfWork<T> where T : DbContext
    {
        public UnitOfWork(T dataContext)
            : base()
        {
            _dataContext = dataContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
                return (IRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext));
            return _repositories[type];
        }
    }
}
