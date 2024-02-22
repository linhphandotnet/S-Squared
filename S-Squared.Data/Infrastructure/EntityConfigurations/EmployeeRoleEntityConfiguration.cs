using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace S_Squared.Data.Infrastructure.EntityConfigurations
{
    public class EmployeeRoleEntityConfiguration : IEntityTypeConfiguration<EmployeeRoles>
    {
        public void Configure(EntityTypeBuilder<EmployeeRoles> builder)
        {
            builder.ToTable("EmployeeRole").HasKey(e => new { e.RoleId, e.EmployeeId });
        }
    }
}
