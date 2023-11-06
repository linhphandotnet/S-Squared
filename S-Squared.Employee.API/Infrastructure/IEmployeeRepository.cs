using S_Squared.EmployeeAPI.Models;

namespace S_Squared.EmployeeAPI.Infrastructure
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByKeyAsync(int id);
        Task<Employee> GetByIDAsync(string employeeId);
        Task<List<Employee>> GetByLasNameAsync(string lastName);
        Task<List<Employee>> GetByFirstNameAsync(string firstName);
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetByManagerAsync(int? key);
        Task<List<Employee>> GetManagersAsync();
        Task<bool> IsEmployeeExist(string  employeeId);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}
