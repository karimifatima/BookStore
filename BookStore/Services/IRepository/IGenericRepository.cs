using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            List<string> includes = null
        );

        Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);

        void Insert(T entity);

        Task Delete(int id);

        void Update(T entity);
        void SaveChangesAsync();
    }
}