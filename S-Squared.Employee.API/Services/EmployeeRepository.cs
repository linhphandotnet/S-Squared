namespace S_Squared.EmployeeAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly S_SquaredDBContext _context;
        public EmployeeRepository(S_SquaredDBContext context) { 
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetByFirstNameAsync(string firstName)
        {
            return await _context.Employees.Where(e => e.FirstName == firstName).ToListAsync();
        }

        public async Task<Employee> GetByIDAsync(string employeeId)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> GetByKeyAsync(int id)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> GetByLasNameAsync(string lastName)
        {
            return await _context.Employees.Where(e => e.LastName == lastName).ToListAsync();
        }

        public async Task<List<Employee>> GetByManagerAsync(int? key)
        {
            return await _context.Employees.Where(e => e.ManagerId == key).ToListAsync();
        }

        public async Task<List<Employee>> GetManagersAsync()
        {
            return await _context.Employees.Where(e => e.IsManager).ToListAsync();    
        }
        
        public void CreateEmployee(Employee employee)
        {
            var exitingEmployee = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);

            if (exitingEmployee is null)
            {
                if(employee.Roles is not null && employee.Roles.Count > 0)
                {
                    _context.EmployeesRoles.AddRange(employee.Roles);
                }

                _context.Employees.Add(employee);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            var exitingEmployee = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);

            if(exitingEmployee is not null)
            {
                _context.EmployeesRoles.UpdateRange(employee.Roles);
                _context.Employees.Update(employee);
            }
        }
        public bool DeleteEmployee(int id)
        {
            var exitingEmployee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if(exitingEmployee is not null)
            {
                _context.Employees.Remove(exitingEmployee);
                return true;
            }

            return false;
        }

        public async Task<bool> SaveChangeAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> IsEmployeeExist(string employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if(employee is not null)
            {
                return true;
            }

            return false;
        }

    }
}
