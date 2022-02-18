namespace CP.BLL.Services
{
    /// <summary>
    /// Manages teams of employees.
    /// </summary>
    /// <typeparam name="TDTO"></typeparam>
    public interface IService<TDTO> where TDTO : class
    {
        /// <summary>
        /// Gets all entities to DTOs.
        /// </summary>
        /// <returns></returns>
        Task<IList<TDTO>> GetAllAsync();

        /// <summary>
        /// Gets an entity by ID to DTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TDTO> GetOneAsync(int id);

        /// <summary>
        /// Creates an entity from DTO.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TDTO> CreateAsync(TDTO dto);

        /// <summary>
        /// Updates an existing entity from DTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, TDTO dto);

        /// <summary>
        /// Deletes an entity by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
