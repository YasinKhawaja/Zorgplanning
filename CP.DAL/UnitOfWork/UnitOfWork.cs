using CP.DAL.Repositories;

namespace CP.DAL.UnitOfWork
{
    /// <summary>
    /// Implements the <seealso cref="IUnitOfWork"/> interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarePlannerContext _context;

        public ITeamRepository Teams { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <seealso cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public UnitOfWork(CarePlannerContext context)
        {
            _context = context;
            Teams = new TeamRepository(context);
            Employees = new EmployeeRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
