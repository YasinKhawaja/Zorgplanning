using CP.DAL.Configurations;
using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL
{
    /// <summary>
    /// Represents a session with the database.
    /// </summary>
    public class CarePlannerContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Regime> Regimes { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Date> Dates { get; set; }

        public CarePlannerContext(DbContextOptions<CarePlannerContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Applies configurations of the models.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TeamConfig().Configure(modelBuilder.Entity<Team>());
            new EmployeeConfig().Configure(modelBuilder.Entity<Employee>());
            new RegimeConfig().Configure(modelBuilder.Entity<Regime>());
            new AbsenceConfig().Configure(modelBuilder.Entity<Absence>());
            new DateConfig().Configure(modelBuilder.Entity<Date>());
        }
    }
}
