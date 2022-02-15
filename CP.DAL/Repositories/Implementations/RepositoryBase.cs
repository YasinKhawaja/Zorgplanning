using CP.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CP.DAL.Repositories.Implementations
{
    /// <summary>
    /// Implements the <seealso cref="IRepositoryBase{T}"/> interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarePlannerContext CarePlannerContext { get; set; }

        public RepositoryBase(CarePlannerContext context)
        {
            this.CarePlannerContext = context;
        }

        public IQueryable<T> FindAll()
        {
            return this.CarePlannerContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CarePlannerContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task CreateAsync(T entity)
        {
            await this.CarePlannerContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            this.CarePlannerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.CarePlannerContext.Set<T>().Remove(entity);
        }
    }
}
