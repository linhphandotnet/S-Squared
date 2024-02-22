

namespace S_Squared.EmployeeAPI.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly S_SquaredDBContext _context;
        public RoleRepository(S_SquaredDBContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await _context.Roles.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role> GetByName(string name)
        {
            return await _context.Roles.SingleOrDefaultAsync(r=>r.RoleName == name);
        }

        public void CreateRole(Role role)
        {
            if (!_context.Roles.Any(r => r.RoleName == role.RoleName))
            {
                _context.Roles.Add(role);
            }
        }

        public void UpdateRole(Role role)
        {
            var exsitingRole = _context.Roles.SingleOrDefault(r=>r.RoleName == role.RoleName || r.Id == role.Id);

            if (exsitingRole is null)
            {
                _context.Roles.Update(role);
            }
        }
        public bool DeleteRole(int id)
        {
            var employeeRole = _context.EmployeesRoles.SingleOrDefault(e => e.RoleId == id);

            if (employeeRole != null)
            {
                return false;
            }

            _context.EmployeesRoles.Remove(employeeRole);
            
            return true;
        }

        public async Task<bool> SaveChangeAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
