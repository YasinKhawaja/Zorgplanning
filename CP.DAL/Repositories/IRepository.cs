using System.Linq.Expressions;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages generic entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously finds all entities.
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> FindAllAsync(
            string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// Asynchronously finds all entities by condition.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<IList<T>> FindByAsync(
            Expression<Func<T, bool>> expression,
            string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// Asynchronously creates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}
