using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="CalendarDate"/> model.
    /// </summary>
    public class DateConfig : IEntityTypeConfiguration<CalendarDate>
    {
        /// <summary>
        /// Configures the <seealso cref="CalendarDate"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<CalendarDate> builder)
        {
            builder.Property(x => x.DateId).HasColumnType("date");
            builder.Property(x => x.IsHoliday).HasDefaultValue(false);
        }
    }
}
