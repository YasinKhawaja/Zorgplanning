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
        public IRegimeRepository Regimes { get; private set; }
        public IAbsenceRepository Absences { get; private set; }
        public IDateRepository Dates { get; private set; }
        public IShiftRepository Shifts { get; private set; }
        public IScheduleRepository Schedules { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <seealso cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public UnitOfWork(CarePlannerContext context)
        {
            _context = context;
            Teams = new TeamRepository(context);
            Employees = new EmployeeRepository(context);
            Regimes = new RegimeRepository(context);
            Absences = new AbsenceRepository(context);
            Dates = new DateRepository(context);
            Shifts = new ShiftRepository(context);
            Schedules = new ScheduleRepository(context);
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
