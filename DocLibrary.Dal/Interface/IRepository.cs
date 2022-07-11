using DocLibrary.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Dal.Interface
{
    public interface IRepository<TEntity> : IQueryable<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(object id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(object id);
    }
}
