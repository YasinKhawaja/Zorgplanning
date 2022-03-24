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
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasColumnType("char(1)")
                .IsRequired();

            builder.Property(x => x.Address1)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Address2)
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.ZipCode)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Town)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Country)
                .HasColumnType("nvarchar(100)")
                .HasDefaultValue(Country.Belgium)
                .IsRequired();

            builder.Property(x => x.IsFixedNight)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

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
