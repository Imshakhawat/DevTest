using Ecom.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Ecom.Domain.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Edit(TEntity entityToUpdate);
        Task EditAsnc(TEntity entityToUpdate);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);

        (IList<TEntity> data, int total, int totalDisplay) Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int PageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Orderby=null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>> include = null, int pageIndex=1, int pageSize=10, bool isTrackingOff= false);

        TEntity GetByID(TKey id);
        TEntity GetByIdAsync(TKey id);

        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        Task<int> GenCountAsync(Expression<Func<TEntity, bool>> filter = null);

        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
       
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        Task<IList<TEntity>> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);

        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        void Remove(TEntity entityToDelete);

        void Remove(TKey id);

        Task RemoveAsync(Expression<Func<TEntity, bool>> filter);

        Task RemoveAsync(TEntity entityToDelete);

        Task RemoveAsync(TKey id);

        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);


    }
}
