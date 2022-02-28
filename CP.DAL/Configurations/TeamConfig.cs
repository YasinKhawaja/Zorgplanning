using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP.DAL.Configurations
{
    /// <summary>
    /// Configures the <seealso cref="Team"/> model.
    /// </summary>
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        /// <summary>
        /// Configures the <seealso cref="Team"/> model.
        /// </summary>
        /// <param name="builder">The configuration builder.</param>
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
