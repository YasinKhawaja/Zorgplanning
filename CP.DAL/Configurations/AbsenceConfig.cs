using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Absence"/> model.
    /// </summary>
    public class AbsenceConfig : IEntityTypeConfiguration<Absence>
    {
        /// <summary>
        /// Configures the <seealso cref="Absence"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Absence> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.DateId });

            builder.Property(x => x.Type)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
