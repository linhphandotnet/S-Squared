
namespace S_Squared.Data.Infrastructure.Datas
{
    public class SeedData
    {
        public async Task SeedDataAsync(S_SquaredDBContext context, ILogger<SeedData> logger)
        {
            //Create default data for Role table
            if (!context.Roles.Any())
            {
                List<Role> roles = new List<Role>();
                roles.Add(new Role { RoleName = "Director" });
                roles.Add(new Role { RoleName = "It" });
                roles.Add(new Role { RoleName = "Support" });
                roles.Add(new Role { RoleName = "Analyst" });
                roles.Add(new Role { RoleName = "Accounting" });
                roles.Add(new Role { RoleName = "Sales" });

                context.Roles.AddRange(roles);
                logger.LogInformation("Generating default data for role table");
                await context.SaveChangesAsync();
            }
            //Create Employee data fro table Employee

            if (!context.Employees.Any())
            {
                List<Employee> employees = new List<Employee>();
                Employee employee = new Employee
                {
                    EmployeeId = "Emp_001",
                    FirstName = "Jeffrey",
                    LastName = "Wells",
                    IsManager = true,
                    ManagerId = null
                };

                employee.Roles = new List<EmployeeRoles> { new EmployeeRoles { EmployeeId = 1, RoleId = 1 } };

                employees.Add(employee);

                employee = new Employee
                {
                    EmployeeId = "Emp_002",
                    FirstName = "Victor",
                    LastName = "Atkins",
                    IsManager = true,
                    ManagerId = 1
                };

                employee.Roles = new List<EmployeeRoles> { new EmployeeRoles { EmployeeId = 2, RoleId = 1 } };
                employees.Add(employee);

                employee = new Employee
                {
                    EmployeeId = "Emp_003",
                    FirstName = "Kelli",
                    LastName = "Hamilton",
                    IsManager = true,
                    ManagerId = 1
                };

                employee.Roles = new List<EmployeeRoles> { new EmployeeRoles { EmployeeId = 3, RoleId = 1 } };
                employees.Add(employee);

                context.Employees.AddRange(employees);
                logger.LogInformation("Generating default data for Employee table");

                await context.SaveChangesAsync();
            }


        }
 }
}
