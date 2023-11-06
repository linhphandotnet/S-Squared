using S_Squared.EmployeeAPI.Infrastructure.EntityConfigurations;

namespace S_Squared.EmployeeAPI.Infrastructure.Data
{
    public class S_SquaredDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRoles> EmployeesRoles { get; set; }


        public S_SquaredDBContext(DbContextOptions<S_SquaredDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRoleEntityConfiguration());
        }
    }
}
