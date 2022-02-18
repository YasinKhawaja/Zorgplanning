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

        public UnitOfWork(CarePlannerContext context)
        {
            _context = context;
            Teams = new TeamRepository(context);
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
