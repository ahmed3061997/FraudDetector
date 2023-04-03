using FraudDetector.Domain.Repositories.Base;
using FraudDetector.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FraudDetector.Persistence.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(
            ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual TEntity? GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual async Task<IEnumerable<TEntity>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void DeleteById(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
                dbSet.Remove(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
        public virtual void Update(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
                dbSet.Update(entity);
        }

        public virtual async Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }


    }
}
