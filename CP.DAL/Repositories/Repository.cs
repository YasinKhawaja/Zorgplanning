using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements the <seealso cref="IRepository{T}"/> interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CarePlannerContext CarePlannerContext { get; set; }

        public Repository(CarePlannerContext context)
        {
            this.CarePlannerContext = context;
        }

        public async Task<IList<T>> FindAllAsync(
            string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this.CarePlannerContext.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IList<T>> FindByAsync(
            Expression<Func<T, bool>> expression,
            string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this.CarePlannerContext.Set<T>();
            query = query.Where(expression);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task AddAsync(T entity)
        {
            await this.CarePlannerContext.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            this.CarePlannerContext.Set<T>().Update(entity);
        }

        public virtual void Remove(T entity)
        {
            this.CarePlannerContext.Set<T>().Remove(entity);
        }
    }
}
