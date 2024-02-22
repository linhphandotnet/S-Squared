using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace S_Squared.Data.Infrastructure.EntityConfigurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee")          
                .HasKey(i => i.Id);
            builder.Property(i => i.Id).UseHiLo("employee_seq");

            builder.HasIndex(s => s.EmployeeId).IsUnique();

             builder.Property(i=> i.EmployeeId)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(e => e.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(e => e.ManagerId)
                .IsRequired(false);

            var navigation = builder.Metadata.FindNavigation(nameof(Employee.Roles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
