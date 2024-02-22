using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S_Squared.Data.Models;

namespace S_Squared.Data.Infrastructure.EntityConfigurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role").HasKey(r => r.Id);
            builder.Property(r => r.Id).UseHiLo("role_seq");

            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
