using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Shift"/> model.
    /// </summary>
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        /// <summary>
        /// Configures the <seealso cref="Shift"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(10)")
                .IsRequired();

            builder.Property(x => x.Start)
                .HasColumnType("time(0)");

            builder.Property(x => x.End)
                .HasColumnType("time(0)");

            builder
                .HasOne(x => x.Regime)
                .WithMany(x => x.Shifts)
                .HasForeignKey(x => x.RegimeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
