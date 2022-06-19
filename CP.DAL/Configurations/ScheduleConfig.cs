using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Schedule"/> model.
    /// </summary>
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        /// <summary>
        /// Configures the <seealso cref="Schedule"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.ShiftId, x.DateId });

            builder
                .HasOne(x => x.Employee)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Shift)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.CalendarDate)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.DateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
