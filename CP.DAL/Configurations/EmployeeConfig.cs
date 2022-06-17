using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Employee"/> model.
    /// </summary>
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// Configures the <seealso cref="Employee"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.IsFixedNight)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Regime)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.RegimeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
