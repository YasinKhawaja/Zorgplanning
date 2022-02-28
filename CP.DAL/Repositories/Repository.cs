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

        public async Task<IList<T>> FindAllAsync()
        {
            return await this.CarePlannerContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> FindByAsync(Expression<Func<T, bool>> condition)
        {
            return await this.CarePlannerContext.Set<T>().Where(condition).AsNoTracking().ToListAsync();
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
