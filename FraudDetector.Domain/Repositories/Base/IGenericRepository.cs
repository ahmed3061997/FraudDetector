using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FraudDetector.Domain.Repositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        TEntity? GetById(int id);
        Task<IEnumerable<TEntity>> All();

        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void Update(TEntity entity);
        void Update(int id);
        Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }

}
