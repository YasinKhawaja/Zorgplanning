using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Regime"/> model.
    /// </summary>
    public class RegimeConfig : IEntityTypeConfiguration<Regime>
    {
        /// <summary>
        /// Configures the <seealso cref="Regime"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Regime> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Hours)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();

            builder.Property(x => x.Percentage)
                .IsRequired();
        }
    }
}
