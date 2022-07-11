using DocLibrary.Dal.Interface;
using DocLibrary.Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DocLibrary.Dal.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _dbSet;
        private DbContext _dbContext;

        public Repository(object context)
        {
            var dbContext = context as DbContext;
            if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
                _dbContext = (DbContext)context;
            }
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(object id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return;

            _dbSet.Remove(obj);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet;
            return _dbSet.Where(predicate);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(Convert.ToInt64(id));
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Can not be null!");
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Can not be null!");

            _dbSet.Update(entity);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dbSet.AsNoTracking().AsEnumerable().GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(TEntity); }
        }

        public Expression Expression
        {
            get { return _dbSet.AsNoTracking().AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _dbSet.AsNoTracking().AsQueryable().Provider; }
        }
    }
}
