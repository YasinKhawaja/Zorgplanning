using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Date"/> model.
    /// </summary>
    public class DateConfig : IEntityTypeConfiguration<Date>
    {
        /// <summary>
        /// Configures the <seealso cref="Date"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Date> builder)
        {
            builder.Property(x => x.DateId).HasColumnType("date");
            builder.Property(x => x.IsHoliday).HasDefaultValue(false);
        }
    }
}
