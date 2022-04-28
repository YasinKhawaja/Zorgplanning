using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="CalendarDate"/> model.
    /// </summary>
    public class CalendarDateConfig : IEntityTypeConfiguration<CalendarDate>
    {
        /// <summary>
        /// Configures the <seealso cref="CalendarDate"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<CalendarDate> builder)
        {
            builder.HasKey(x => x.DateId);

            builder.Property(x => x.Date)
                .HasColumnType("date");

            builder.Property(x => x.HolidayName)
                .HasMaxLength(25);
        }
    }
}
