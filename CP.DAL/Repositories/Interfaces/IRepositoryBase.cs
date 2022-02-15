using CP.DAL.Repositories.Implementations;
using System.Linq.Expressions;

namespace CP.DAL.Repositories.Interfaces
{
    /// <summary>
    /// An interface for the <seealso cref="RepositoryBase{T}"/> class.
    /// </summary>
    /// <typeparam name="T">A model class.</typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Finds all entities by condition.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates an entity asynchronously.
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
