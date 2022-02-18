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
        Task<IList<T>> FindAllAsync();

        /// <summary>
        /// Asynchronously finds all entities by condition.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<IList<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Asynchronously creates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
